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
using Entity;
using System.Data.Linq;

namespace XayDungPhanMem
{
    public partial class frmDatTruoc : Form
    {
        TieuDeBUL tieuDeBUL;
        PhieuDatTruocBUL phieuDatTruocBUL;
        KhachHangBUL khachHangBUL;
        DVDBUL dVDBUL;
        int vitri = 0;
        public frmDatTruoc()
        {
            tieuDeBUL = new TieuDeBUL();
            phieuDatTruocBUL = new PhieuDatTruocBUL();
            khachHangBUL = new KhachHangBUL();
            dVDBUL = new DVDBUL();
            InitializeComponent();
            dgv_dstieude.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_dskhdat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DatTruoc_Load(object sender, EventArgs e)
        {
            //var lisptd = from td in tieuDeBUL.getTieuDes()
            //             join pdt in phieuDatTruocBUL.getPhieuDatTruocs()
            //             on td.id_TieuDe equals pdt.id_TieuDe
            //             join dvd in dVDBUL.getDVDs()
            //             on pdt.id_DVD equals dvd.id_DVD
            //             where dvd.trangThai !=1      
            //             select new
            //             {
            //                td.id_TieuDe,
            //                td.tenTieuDe,
            //                td.id_TheLoai
            //             };
            //List<eTieuDe> lst = new List<eTieuDe>();
            //foreach(var item in lisptd)
            //{
            //    eTieuDe td = new eTieuDe();
            //    td.id_TieuDe = item.id_TieuDe;
            //    td.tenTieuDe = item.tenTieuDe;
            //    td.id_TheLoai = item.id_TheLoai;
            //    lst.Add(td);
            //}
            dgv_dstieude.DataSource = tieuDeBUL.getTieuDes();
        }

        public void LoadData(int s)
        {
            List<eKhachHang> listkh = new List<eKhachHang>();
            //Chon ra nhung phieu dat truoc theo tieu de da dat
            // ePhieuDatTruoc bs = tieuDeBUL.FindbyID(s);
            var lispdt = from td in tieuDeBUL.getTieuDes()
                         join pdt in phieuDatTruocBUL.getPhieuDatTruocs()
                         on td.id_TieuDe equals pdt.id_TieuDe
                         where pdt.id_TieuDe == s
                         select new
                         {
                             pdt.id_KhachHang,
                             pdt.id_TieuDe
                         };
            var lit = from p in lispdt
                      join kh in khachHangBUL.getKhachHangs()
                      on p.id_KhachHang equals kh.id_KhachHang
                      select new
                      {
                          kh.id_KhachHang,
                          kh.tenKhachHang,
                          kh.soCMND,
                          kh.soDT
                      };

            foreach (var item in lit)
            {
                eKhachHang ek = new eKhachHang();
                ek.id_KhachHang = item.id_KhachHang;
                ek.tenKhachHang = item.tenKhachHang;
                ek.soCMND = item.soCMND;
                ek.soDT = item.soDT;

                listkh.Add(ek);

            }
            dgv_dskhdat.DataSource = listkh;
        }

        private void dgv_dstieude_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_dstieude.Rows[e.RowIndex];
                //Ma tieu de
                int s = Convert.ToInt32(row.Cells[0].Value.ToString());
                LoadData(s);

            }
            vitri = e.RowIndex;

        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txt_idkh.Text);

            eKhachHang kh = khachHangBUL.Find(id);
            if (kh == null)
            {
                Cleadrr();
                MessageBox.Show("Chưa có khách hàng trong hệ thống");

            }
            else
            {
                txt_idkh.Text = id.ToString();
                txt_sdt.Text = kh.soDT;
                txt_tenkh.Text = kh.tenKhachHang;
            }

        }
        public void Cleadrr()
        {
            txt_tenkh.Text = "";
            txt_sdt.Text = "";
        }
        private void btn_dat_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgv_dstieude.Rows[vitri];
            //Ma tieu de
            int s = Convert.ToInt32(row.Cells[0].Value.ToString());
            ePhieuDatTruoc pdt = new ePhieuDatTruoc();
            int id = Convert.ToInt32(txt_idkh.Text);

            eKhachHang kh = khachHangBUL.Find(id);
            if (kh == null)
            {
                eKhachHang ekh = new eKhachHang();
                ekh.tenKhachHang = txt_tenkh.Text;
                ekh.soDT = txt_sdt.Text;

                khachHangBUL.Save(ekh);
                List<eKhachHang> lst = khachHangBUL.getKhachHangs();
                eKhachHang khh = lst.FirstOrDefault(st => st.soCMND.Equals(ekh.soCMND));

                pdt.id_TieuDe = s;
                pdt.ngayDatTruoc = DateTime.Today;
                pdt.id_KhachHang = khh.id_KhachHang;
                phieuDatTruocBUL.Save(pdt);
                MessageBox.Show("Đặt trước thành công");
            }
            else
            {
                pdt.id_TieuDe = s;
                pdt.ngayDatTruoc = DateTime.Today;
                pdt.id_KhachHang = kh.id_KhachHang;
                phieuDatTruocBUL.Save(pdt);
                MessageBox.Show("Đặt trước thành công");
            }


        }

        private void dgv_dskhdat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgv_dskhdat.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txt_idkh.Text = row.Cells[0].Value.ToString();
                txt_tenkh.Text = row.Cells[1].Value.ToString();
                txt_sdt.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}
