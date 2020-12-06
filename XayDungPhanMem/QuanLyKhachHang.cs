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
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }
        KhachHangBUL khbul = new KhachHangBUL();
        PhieuThueTraBUL thuebul = new PhieuThueTraBUL();
        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            loadDataGridView(dgv_dskh);
        }
        void loadDataGridView(DataGridView d)
        {
            dgv_dskh.DataSource = khbul.getKhachHangs();
            FormatGridView(d);
        }
        void FormatGridView(DataGridView dgv)
        {
            dgv.Columns["id_KhachHang"].HeaderText = "ID";
            dgv.Columns["tenKhachHang"].HeaderText = "Họ và tên";
            dgv.Columns["soDT"].HeaderText = "Điện thoại";
            dgv.Columns["soCMND"].HeaderText = "CMND";

            //set kích thước cột
            dgv.Columns["id_KhachHang"].Width = 50;
            dgv.Columns["tenKhachHang"].Width = 100;
            dgv.Columns["soDT"].Width = 110;
            dgv.Columns["soCMND"].Width =110;
            //set thứ tự cột
            dgv.Columns["id_KhachHang"].DisplayIndex = 0;
            dgv.Columns["tenKhachHang"].DisplayIndex = 1;
            dgv.Columns["soDT"].DisplayIndex = 2;
            dgv.Columns["soCMND"].DisplayIndex = 3;
        }

        private void dgv_dskh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgv_dskh.CurrentCell.RowIndex;
            txt_idkh.Text = dgv_dskh.Rows[vt].Cells["id_KhachHang"].Value.ToString();
            txt_tenkh.Text = dgv_dskh.Rows[vt].Cells["tenKhachHang"].Value.ToString();
            txt_sdt.Text = dgv_dskh.Rows[vt].Cells["soDT"].Value.ToString();
            txt_cmnd.Text = dgv_dskh.Rows[vt].Cells["soCMND"].Value.ToString();
            gdv_ds_dia_dang_thue(Convert.ToInt32(dgv_dskh.Rows[vt].Cells["id_KhachHang"].Value.ToString()));
        }

        private void gdv_ds_dia_dang_thue(int idkh)
        {
            List<ePhieuThueTra> list = thuebul.getPhieuThueTraByKH(idkh);
            DataTable table = new DataTable();
            table.Columns.Add("id_PhieuThue", typeof(int));
            table.Columns.Add("id_DVD", typeof(int));
            table.Columns.Add("ngayThue", typeof(string));
            foreach (ePhieuThueTra item in list)
            {
                table.Rows.Add(item.id_PhieuThue, item.id_DVD, item.ngayThue);
            }
            dgv_dsdiathue.DataSource = table;
            dgv_dsdiathue.Columns["id_PhieuThue"].HeaderText = "Mã phiếu";
            dgv_dsdiathue.Columns["id_DVD"].HeaderText = "Mã DVD";
            dgv_dsdiathue.Columns["ngayThue"].HeaderText = "Ngày thuê";
            dgv_dsdiathue.Columns["id_PhieuThue"].Width = 110;
            dgv_dsdiathue.Columns["id_DVD"].Width = 110;
            dgv_dsdiathue.Columns["ngayThue"].Width = 200;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                eKhachHang ekh = new eKhachHang();
                ekh.tenKhachHang = txt_tenkh.Text.Trim();
                ekh.soCMND = txt_cmnd.Text.Trim();
                ekh.soDT = txt_sdt.Text.Trim();
                khbul.Save(ekh);
                MessageBox.Show("Thêm khách hàng thành công");
                loadDataGridView(dgv_dskh);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm" + ex.Message);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            eKhachHang kh = new eKhachHang();
            int vt = dgv_dskh.CurrentCell.RowIndex;
            kh.id_KhachHang = Convert.ToInt32(dgv_dskh.Rows[vt].Cells["id_KhachHang"].Value.ToString());
            kh.tenKhachHang = txt_tenkh.Text.Trim();
            kh.soDT = txt_sdt.Text.Trim();
            kh.soCMND = txt_cmnd.Text.Trim();
            int kq = khbul.UpdateKhachHang(kh);
            if (kq == 1)
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
                loadDataGridView(dgv_dskh);
            }
            else return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Properties.Settings.Default.useName;
            string pass = Properties.Settings.Default.passWord;
            if (user.Equals("Empty") && pass.Equals("Empty"))
            {
                Login frm = new Login();
                frm.Show();
            }
            else
            {
                int vt = dgv_dskh.CurrentCell.RowIndex;
                string id_KhachHang = dgv_dskh.Rows[vt].Cells["id_KhachHang"].Value.ToString();
                if (id_KhachHang.Equals(""))
                {
                    MessageBox.Show("Hãy chọn khách hàng cần xoá");
                    return;
                }
                int kq = khbul.Delete(Convert.ToInt32(id_KhachHang));
                if (kq == 1)
                {
                    MessageBox.Show("Xoá khách hàng thành công");
                    loadDataGridView(dgv_dskh);
                    return;
                }
            }
        }
    }
}
