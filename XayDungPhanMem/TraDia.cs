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
    public partial class TraDia : Form
    {
        PhieuThueTraBUL phieuTTBul = new PhieuThueTraBUL();
        PhieuDatTruocBUL phieuDatTruocBUL = new PhieuDatTruocBUL();
        const double PHI_TRE_HEN = 0.1;
        PhiTreHenBUL treHenBUL = new PhiTreHenBUL();
        KhachHangBUL khBul = new KhachHangBUL();
        DVDBUL dvdBul = new DVDBUL();
        TieuDeBUL tieuDeBUL = new TieuDeBUL();
        TheLoaiBUL theLoaiBUL = new TheLoaiBUL();
        DataTable table = new DataTable();
        List<eKhachHang> listKH;
        List<eDVD> listDVD;
        Home home;

        public TraDia(Home h)
        {
            InitializeComponent();
            home = h;
            table.Columns.Add("id_PhieuThue", typeof(int));
            table.Columns.Add("id_DVD", typeof(int));
            table.Columns.Add("ngayThue", typeof(string));
            table.Columns.Add("id_kh", typeof(string));
            table.Columns.Add("ten_kh", typeof(string));
        }

        private void btn_tkID_Click(object sender, EventArgs e)
        {
            if (txt_IDDia.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Nhập Id DVD");
                txt_IDDia.Focus();
                return;
            }
            int id_dvd = Convert.ToInt32(txt_IDDia.Text.ToString().Trim());
            ePhieuThueTra phieu = phieuTTBul.getPhieuThueTraByIdDVD(id_dvd);
            if (phieu != null)
            {
                eKhachHang kh = khBul.GetKhachHangByID(phieu.id_KhachHang);
                txt_idkh.Text = kh.id_KhachHang.ToString();
                txt_sdt.Text = kh.soDT;
                txt_tenkh.Text = kh.tenKhachHang;
                txt_tendia.Text = tieuDeBUL.GetTieuDeByID(dvdBul.FindDVDById(id_dvd).id_TieuDe).tenTieuDe;
                table.Rows.Add(phieu.id_PhieuThue, phieu.id_DVD, phieu.ngayThue, kh.id_KhachHang, kh.tenKhachHang);
                LoadData();
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả");
            }
        }

        private void LoadData()
        {
            var newTable = table.DefaultView.ToTable(true); // bỏ trùng
            dgvDsTra.DataSource = newTable;
            FormatGridView(dgvDsTra);
        }

        private void FormatGridView(DataGridView dgv)
        {
            dgv.Columns["id_PhieuThue"].HeaderText = "Mã phiếu";
            dgv.Columns["id_DVD"].HeaderText = "Mã DVD";
            dgv.Columns["ngayThue"].HeaderText = "Ngày thuê";
            dgv.Columns["id_kh"].Visible = false;
            dgv.Columns["ten_kh"].HeaderText = "Tên khách hàng";

            //set kích thước cột
            dgv.Columns["id_PhieuThue"].Width = 80;
            dgv.Columns["id_DVD"].Width = 80;
            dgv.Columns["ngayThue"].Width = 150;
            dgv.Columns["ten_kh"].Width = 200;
        }

        private void btn_tradia_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            listKH = new List<eKhachHang>();
            listDVD = new List<eDVD>();
            int count = 0;
            foreach (DataGridViewRow row in dgvDsTra.Rows)
            {
                int id_phieu = Convert.ToInt32(row.Cells[0].Value.ToString());
                DateTime ngayThue = Convert.ToDateTime(row.Cells[2].Value.ToString());
                int id_dvd = Convert.ToInt32(row.Cells[1].Value.ToString());
                double time = theLoaiBUL.GetTheLoaiByID(tieuDeBUL.GetTieuDeByID(dvdBul.FindDVDById(id_dvd).id_TieuDe).id_TheLoai).thoiGianThue;
                eDVD dvd = dvdBul.FindDVDById(id_dvd);
                if (!listDVD.Contains(dvd))
                {
                    listDVD.Add(dvd);
                }
                eKhachHang kh = khBul.Find(Convert.ToInt32(row.Cells[3].Value.ToString()));
                if (!listKH.Contains(kh))
                {
                    listKH.Add(kh);
                }
                if ((now - ngayThue).TotalDays > time)
                {
                    count = phieuTTBul.UpdatePhieuThue_Tre(id_phieu, now, PHI_TRE_HEN);
                }
                else
                {
                    count = phieuTTBul.UpdatePhieuThue(id_phieu, now, now, 0);
                }
                dvdBul.UpdateTrangThaiDVD(id_dvd, -1);
            }
            if (count == 1)
            {
                MessageBox.Show("Trả đĩa thành công");
                table.Clear();
                LoadData();
            }
            CheckPhiTreHen();
            UpdateDVDDatTruoc();
        }

        private void UpdateDVDDatTruoc()
        {
            List<ePhieuDatTruoc> list = phieuDatTruocBUL.getPhieuDatTruocs();
            foreach (ePhieuDatTruoc item in list)
            {
                foreach (eDVD dVD in listDVD)
                {
                    if (item.id_TieuDe == dVD.id_TieuDe)
                    {
                        eKhachHang kh = khBul.Find(item.id_KhachHang);
                        eTieuDe tieuDe = tieuDeBUL.Find(dVD.id_TieuDe);
                        string text = "Khách hàng: " + kh.tenKhachHang + "\nSố điện thoại: " + kh.soDT + "\n Muốn tiếp tục giữ lại DVD có tiêu đề: "
                                + tieuDe.tenTieuDe + "\n Hãy thông báo với khách hàng";
                        DialogResult dialogResult = MessageBox.Show(text, "Thông báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            phieuDatTruocBUL.Update(item.id_PhieuDatTruoc, dVD.id_DVD);
                            MessageBox.Show("Đã giữ DVD lại cho khách hàng");
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            phieuDatTruocBUL.DeletePDTByIDPhieu_IDTieuDe(item.id_PhieuDatTruoc);
                            MessageBox.Show("Huỷ yêu cầu đặt trước dvd của khách hàng thành công");
                        }
                    }
                }
            }
        }

        private void CheckPhiTreHen()
        {
            foreach (eKhachHang kh in listKH)
            {
                List<ePhieuThueTra> listPhieu = treHenBUL.getListPhiTreHen(kh.id_KhachHang);
                if (listPhieu != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Khách hàng hiện đang nợ một số phí trễ hẹn. " +
                        "Có muốn thanh toán hay không?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ChiTietTreHan frm = new ChiTietTreHan(listPhieu, kh);
                        frm.MdiParent = home;
                        frm.Show();
                        this.Close();
                    }
                }
            }
        }

        private void btnXoaRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDsTra.SelectedRows)
            {
                List<DataRow> datas = new List<DataRow>();
                foreach (DataRow item in table.Rows)
                {
                    if (item["id_PhieuThue"].ToString().Equals(row.Cells[0].Value.ToString()))
                    {
                        datas.Add(item);
                    }
                }
                foreach (DataRow item in datas)
                {
                    table.Rows.Remove(item);
                }
                LoadData();
            }
        }
    }
}
