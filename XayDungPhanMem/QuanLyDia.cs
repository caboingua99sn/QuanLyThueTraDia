using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BULL;
using System.Data.Entity;
using Entity;

namespace XayDungPhanMem
{
    public partial class frmQuanlydia : Form
    {
        TieuDeBUL tieuDeBUL;
        DVDBUL dVDBUL;
        TheLoaiBUL theLoaiBUL;
        private BindingSource binding = new BindingSource();

        public frmQuanlydia()
        {
            dVDBUL = new DVDBUL();
            tieuDeBUL = new TieuDeBUL();
            theLoaiBUL = new TheLoaiBUL();
            InitializeComponent();
            dgv_dsdia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void Clearr()
        {
            txtgiathue.Text = "";
            txttgthue.Text = "";
            txt_iddia.Text = "";
            txt_tendia.Text = "";
            txt_tragthai.Text = "";
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            Clearr();
            if (nhapid.Text != "")
            {
                int id = Convert.ToInt32(nhapid.Text);
                eDVD dvd = dVDBUL.FindDVDById(id);
                if (dvd != null)
                {
                    eTieuDe tieuDe = tieuDe = tieuDeBUL.Find(dvd.id_TieuDe);
                    eTheLoai theLoai = tieuDeBUL.FindTheLoaiById(tieuDe.id_TheLoai);
                    txt_tendia.Text = tieuDe.tenTieuDe;
                    txtgiathue.Text = theLoai.giaThue.ToString();
                    txttgthue.Text = theLoai.thoiGianThue.ToString();
                    txt_iddia.Text = dvd.id_DVD.ToString();
                    if (dvd.trangThai == -1)
                    {
                        txt_tragthai.Text = "Trên kệ";
                    }
                    else if (dvd.trangThai == 0)
                    {
                        txt_tragthai.Text = "Đang giữ";
                    }
                    else
                    {
                        txt_tragthai.Text = "Đã thuê";
                    }
                    btn_timkiem.Text = " Tìm kiếm";
                }
                else
                {
                    MessageBox.Show("Không có đĩa trong danh sách");
                }
            }
            else
            {
                MessageBox.Show("Nhập mã cần tìm");
            }
        }

        public void btn_them_Click(object sender, EventArgs e)
        {
            ThemDVD them = new ThemDVD();
            them.ShowDialog();
            LoadData();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_dsdia.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(txt_iddia.Text);
                dVDBUL.DeleteDVD(id);
                LoadData();
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đĩa bạn muốn xóa");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLyDia_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private DataTable ConvertListToDataTable(List<eDVD> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add("id_DVD", typeof(int));
            table.Columns.Add("id_TieuDe", typeof(int));
            table.Columns.Add("trangThai", typeof(int));
            table.Columns.Add("string_TieuDe", typeof(string));
            table.Columns.Add("string_trangThai", typeof(string));

            foreach (eDVD item in list)
            {
                string trangthai = "";
                if (item.trangThai == -1)
                {
                    trangthai = "Trên kệ";
                }
                else if (item.trangThai == 0)
                {
                    trangthai = "Đang giữ";
                }
                else
                {
                    trangthai = "Đã thuê";
                }
                table.Rows.Add(item.id_DVD, item.id_TieuDe,item.trangThai, tieuDeBUL.GetTieuDeByID(item.id_TieuDe).tenTieuDe, trangthai);
            }
            return table;
        }

        public void LoadData()
        {
            List<eDVD> list = dVDBUL.getDVDs();
            dgv_dsdia.DataSource = ConvertListToDataTable(list);
            FormatGridView(dgv_dsdia);
        }

        void FormatGridView(DataGridView dgv)
        {
            dgv.Columns["id_TieuDe"].Visible = false;
            dgv.Columns["trangThai"].Visible = false;
            dgv.Columns["id_DVD"].HeaderText = "ID";
            dgv.Columns["string_TieuDe"].HeaderText = "Tiêu đề";
            dgv.Columns["string_trangThai"].HeaderText = "Trạng thái";

            //set kích thước cột
            dgv.Columns["id_DVD"].Width = 50;
            dgv.Columns["string_TieuDe"].Width = 220;
            dgv.Columns["string_trangThai"].Width = 110;

            //set thứ tự cột
            dgv.Columns["id_DVD"].DisplayIndex = 0;
            dgv.Columns["id_TieuDe"].DisplayIndex = 3;
            dgv.Columns["string_trangThai"].DisplayIndex = 4;
        }

        private void dgv_dsdia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgv_dsdia.Rows[e.RowIndex];
                if (!row.Cells[1].Value.ToString().Trim().Equals(""))
                {
                    //Lưu lại dòng dữ liệu vừa kích chọn
                    //Đưa dữ liệu vào textbox
                    txt_iddia.Text = row.Cells[0].Value.ToString();
                    txt_tragthai.Text = row.Cells[4].Value.ToString();
                    int s = Convert.ToInt32(row.Cells[1].Value.ToString());
                    eTieuDe tieuDe = new eTieuDe();
                    eTheLoai theLoai = new eTheLoai();
                    tieuDe = tieuDeBUL.Find(s);
                    theLoai = theLoaiBUL.FindDVDById(tieuDe.id_TheLoai);
                    txt_tendia.Text = tieuDe.tenTieuDe;
                    txtgiathue.Text = theLoai.giaThue.ToString();
                    txttgthue.Text = theLoai.thoiGianThue.ToString();
                }
            }
        }
    }
}
