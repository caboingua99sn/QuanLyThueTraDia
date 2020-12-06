using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BULL;

namespace XayDungPhanMem
{
    public partial class ChiTietTreHan : Form
    {
        List<ePhieuThueTra> listThueHen = new List<ePhieuThueTra>();
        eKhachHang kh = new eKhachHang();
        const double PHI_TRE_HEN = 0.1;
        DVDBUL dVDBUL = new DVDBUL();
        PhiTreHenBUL phiTreHenBUL = new PhiTreHenBUL();
        KhachHangBUL khachHangBUL = new KhachHangBUL();
        TieuDeBUL tieuDeBUL = new TieuDeBUL();
        TheLoaiBUL tlbus = new TheLoaiBUL();
        double tongTien = 0;
        int idkh = 0;

        public ChiTietTreHan()
        {
            InitializeComponent();
            txtidkh.ReadOnly = false;
            btnTim.Visible = true;
        }

        public ChiTietTreHan(List<ePhieuThueTra> listThueHenstr, eKhachHang khstr)
        {
            InitializeComponent();
            btnTim.Visible = false;
            kh = khstr;
            idkh = khstr.id_KhachHang;
            listThueHen = listThueHenstr;
        }

        private void LoadData(List<ePhieuThueTra> list)
        {
            dgvPhiTreHen.DataSource = ConvertListToDataTable(list);
            FormartDataGridView(dgvPhiTreHen);
        }

        private void FormartDataGridView(DataGridView dgv)
        {
            dgv.Columns["id_PhieuThue"].HeaderText = "Mã phiếu";
            dgv.Columns["id_DVD"].HeaderText = "Mã DVD";
            dgv.Columns["ngayThue"].HeaderText = "Ngày thuê";
            dgv.Columns["ngayTra"].HeaderText = "Ngày trả";
            dgv.Columns["phiTreHan"].HeaderText = "Phí trễ hạn";

            //set kích thước cột
            dgv.Columns["id_PhieuThue"].Width = 90;
            dgv.Columns["id_DVD"].Width = 80;
            dgv.Columns["ngayThue"].Width = 150;
            dgv.Columns["ngayTra"].Width = 150;
            dgv.Columns["phiTreHan"].Width = 130;
        }

        private DataTable ConvertListToDataTable(List<ePhieuThueTra> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add("id_PhieuThue", typeof(int));
            table.Columns.Add("id_DVD", typeof(int));
            table.Columns.Add("ngayThue", typeof(string));
            table.Columns.Add("ngayTra", typeof(string));
            table.Columns.Add("phiTreHan", typeof(double));
            foreach (ePhieuThueTra item in list)
            {
                double phiThue = tlbus.GetTheLoaiByID(tieuDeBUL.GetTieuDeByID(dVDBUL.FindDVDById(item.id_DVD).id_TieuDe).id_TheLoai).giaThue;
                table.Rows.Add(item.id_PhieuThue, item.id_DVD, item.ngayThue.ToString(), item.ngayTra.ToString(), phiThue * PHI_TRE_HEN);
            }
            return table;
        }

        private void ChiTietTreHan_Load(object sender, EventArgs e)
        {
            LoadData(listThueHen);
            txtidkh.Text = kh.id_KhachHang.ToString();
            txthotenkh.Text = kh.tenKhachHang;
            txtsdt.Text = kh.soDT;
            foreach (DataGridViewRow row in dgvPhiTreHen.Rows)
            {
                tongTien += Convert.ToDouble(row.Cells[4].Value.ToString());
            }
            txtTienThanhToan.Text = tongTien.ToString();
        }

        private void btnThanhToanPhiTreHan_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            int count = 0;
            foreach (DataGridViewRow row in dgvPhiTreHen.Rows)
            {
                int id_dvd = Convert.ToInt32(row.Cells[1].Value.ToString());
                count = phiTreHenBUL.ThanhToanPhiTreHen(idkh, id_dvd, now);
            }
            if (count == 1)
            {
                MessageBox.Show("Thanh toán phí trễ hẹn thành công");
                listThueHen.Clear();
                LoadData(listThueHen);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            List<int> id_Phieus = new List<int>();
            foreach (DataGridViewRow row in dgvPhiTreHen.SelectedRows)
            {
                id_Phieus.Add(Convert.ToInt32(row.Cells[0].Value.ToString()));
                tongTien -= Convert.ToDouble(row.Cells[4].Value.ToString());
            }
            foreach (int id_phieu in id_Phieus)
            {
                foreach (ePhieuThueTra item in listThueHen)
                {
                    if (id_phieu == item.id_PhieuThue)
                    {
                        listThueHen.Remove(item);
                        break;
                    }
                }
            }
            LoadData(listThueHen);
            txtTienThanhToan.Text = tongTien.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (!txtidkh.Text.ToString().Trim().Equals(""))
            {
                eKhachHang kh = khachHangBUL.Find(Convert.ToInt32(txtidkh.Text.ToString().Trim()));
                if (kh != null)
                {
                    idkh = kh.id_KhachHang;
                    txthotenkh.Text = kh.tenKhachHang;
                    txtidkh.Text = kh.id_KhachHang.ToString();
                    txtsdt.Text = kh.soDT;
                    listThueHen = phiTreHenBUL.getListPhiTreHen(kh.id_KhachHang);
                    LoadData(listThueHen);
                    foreach (DataGridViewRow row in dgvPhiTreHen.Rows)
                    {
                        tongTien += Convert.ToDouble(row.Cells[4].Value.ToString());
                    }
                    txtTienThanhToan.Text = tongTien.ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng");
                }
            }
            else
            {
                MessageBox.Show("ID khách hàng không để trống");
                return;
            }
        }
    }
}
