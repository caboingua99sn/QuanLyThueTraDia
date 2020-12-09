using BULL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XayDungPhanMem
{
    public partial class BaoCaoKhachHang : Form
    {
        KhachHangBUL khbul;
        PhieuThueTraBUL phieu;
        TieuDeBUL td;
        TheLoaiBUL tl;
        DVDBUL dvd;
        public BaoCaoKhachHang()
        {
            InitializeComponent();
        }

        private void BaoCaoKhachHang_Load(object sender, EventArgs e)
        {
            khbul = new KhachHangBUL();
            phieu = new PhieuThueTraBUL();
            td = new TieuDeBUL();
            tl = new TheLoaiBUL();
            dvd = new DVDBUL();

            List<eKhachHang> ls = khbul.getKhachHangs();
            dgv_dskh.DataSource = ls;
            FormatLaiDataGridviewkh(dgv_dskh);

            txt_totalkhnop.Text = tongkhno().ToString();
            txt_totaldiatra.Text = tongkhthue().ToString();

            cb_listkh.Items.Add("Tất Cả");
            cb_listkh.Items.Add("Khách hàng quá hạn trả đĩa");
            cb_listkh.Items.Add("Khách hàng nợ phí trễ hạn");
            cb_listkh.SelectedIndex = 0;
        }
        void FormatLaiDataGridviewkh(DataGridView dgv)
        {
            dgv.Columns["id_KhachHang"].HeaderText = "ID";
            dgv.Columns["id_KhachHang"].Width = 30;
            dgv.Columns["tenKhachHang"].Width = 130;
            dgv.Columns["tenKhachHang"].HeaderText = "Tên Khách Hàng";
            dgv.Columns["soCMND"].Width = 80;
            dgv.Columns["soCMND"].HeaderText = "CMND";
            dgv.Columns["soDT"].HeaderText = "SDT";
        }

        void FormatLaiDataGridviewdia(DataGridView dgv)
        {
            dgv.Columns["id_PhieuThue"].HeaderText = "ID";
            dgv.Columns["id_PhieuThue"].Width = 30;
            dgv.Columns["ngayThue"].Width = 90;
            dgv.Columns["ngayThue"].HeaderText = "Ngày thuê";
            dgv.Columns["ngayTra"].Width = 90;
            dgv.Columns["ngayTra"].HeaderText = "Ngày trả";
            dgv.Columns["ngayTraPhiTreHen"].Visible = false;
            dgv.Columns["id_DVD"].Width = 50;
            dgv.Columns["id_DVD"].HeaderText = "ID_DVD";
            dgv.Columns["id_KhachHang"].Visible = false;
        }
        private int tongkhno()
        {
            List<eKhachHang> lskh = khbul.getKhachHangs();
            int i = 0;
            foreach (var item in lskh)
            {
                List<ePhieuThueTra> lsp = phieu.getPhieuThueTraByKHBaoCao(item.id_KhachHang);
                foreach (var item1 in lsp)
                {
                    if (item1.ngayTraPhiTreHen == null)
                    {
                        i++;
                        break;
                    }
                }
            }
            return i;
        }
        private int tongkhthue()
        {
            List<eKhachHang> lskh = khbul.getKhachHangs();
            int i = 0;
            foreach (var item in lskh)
            {
                List<ePhieuThueTra> lsp = phieu.getPhieuThueTraByKHBaoCao(item.id_KhachHang);
                foreach (var item1 in lsp)
                {
                    if (item1.ngayTra == null)
                    {
                        i++;
                        break;
                    }
                }
            }
            return i;
        }

        private void cb_listkh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_listkh.SelectedIndex == 1)
            {
                List<eKhachHang> lskh = khbul.getKhachHangs();
                List<eKhachHang> lskh1 = new List<eKhachHang>();
                foreach (var item in lskh)
                {
                    List<ePhieuThueTra> lsp = phieu.getPhieuThueTraByKHBaoCao(item.id_KhachHang);
                    foreach (var item1 in lsp)
                    {
                        eDVD dvd1 = dvd.FindDVDById(item1.id_DVD);
                        eTieuDe t = td.GetTieuDeByID(dvd1.id_TieuDe);
                        eTheLoai theloai = tl.GetTheLoaiByID(t.id_TheLoai);
                        DateTime dt = (DateTime)item1.ngayThue;
                        DateTime today = DateTime.Now;
                        if (item1.ngayTra == null && DateTime.Compare(today, dt) == 1)
                        {
                            lskh1.Add(item);
                            break;
                        }
                    }
                }
                dgv_dskh.DataSource = lskh1;
                FormatLaiDataGridviewkh(dgv_dskh);
            }
            else if (cb_listkh.SelectedIndex == 0)
            {
                List<eKhachHang> ls = khbul.getKhachHangs();
                dgv_dskh.DataSource = ls;
                FormatLaiDataGridviewkh(dgv_dskh);
            }
            else
            {
                List<eKhachHang> lskh = khbul.getKhachHangs();
                List<eKhachHang> lskh1 = new List<eKhachHang>();
                foreach (var item in lskh)
                {
                    List<ePhieuThueTra> lsp = phieu.getPhieuThueTraByKHBaoCao(item.id_KhachHang);
                    foreach (var item1 in lsp)
                    {
                        if (item1.ngayTraPhiTreHen == null)
                        {
                            lskh1.Add(item);
                            break;
                        }
                    }
                }
                dgv_dskh.DataSource = lskh1;
                FormatLaiDataGridviewkh(dgv_dskh);
            }
        }

        private void dgv_dskh_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgv_dskh.SelectedRows.Count > 0)
            {
                string str = e.Row.Cells["id_KhachHang"].Value.ToString();
                txt_idkh.Text = str;
                txt_tenkh.Text = e.Row.Cells["tenKhachHang"].Value.ToString();
                txt_sdt.Text = e.Row.Cells["soDT"].Value.ToString();
                txt_cmnd.Text = e.Row.Cells["soCMND"].Value.ToString();
                txt_phino.Text = phieu.totalPhi(Convert.ToInt32(str)).ToString();
                txt_totaldia.Text = tongdia(Convert.ToInt32(str)).ToString();
                List<ePhieuThueTra> lsp = phieu.getPhieuThueTraByKHBaoCao(Convert.ToInt32(str)).Where(x => x.ngayTraPhiTreHen == null).ToList();
                dgv_dsdiathue.DataSource = lsp;
                FormatLaiDataGridviewdia(dgv_dsdiathue);
            }
        }

        private void dgv_dsdiathue_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgv_dsdiathue.SelectedRows.Count > 0)
            {
                string str = e.Row.Cells["id_DVD"].Value.ToString();
                eTieuDe t = td.GetTieuDeByID(Convert.ToInt32(str));
                txt_tieude.Text = t.tenTieuDe;
                eTheLoai theloai = tl.GetTheLoaiByID(t.id_TheLoai);
                DateTime dt = (DateTime)e.Row.Cells["ngayThue"].Value;
                txt_nghethan.Text = dt.AddDays(theloai.thoiGianThue).ToShortDateString();
            }
        }
        private int tongdia(int id)
        {
            List<ePhieuThueTra> lsp = phieu.getPhieuThueTraByKH(id).ToList();
            int i = 0;
            foreach (var item in lsp)
            {
                if (item.ngayTra == null)
                {
                    i++;
                }
            }
            return i;
        }
    }
}
