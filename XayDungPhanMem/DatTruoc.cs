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
        ContextMenuStrip contextMenu;
        TieuDeBUL tieuDeBUL;
        PhieuDatTruocBUL phieuDatTruocBUL;
        KhachHangBUL khachHangBUL;
        DVDBUL dVDBUL;
        int vitri = 0;
        int vitrikh = 0;
        public frmDatTruoc()
        {
            tieuDeBUL = new TieuDeBUL();
            phieuDatTruocBUL = new PhieuDatTruocBUL();
            khachHangBUL = new KhachHangBUL();
            dVDBUL = new DVDBUL();
            InitializeComponent();
            dgv_dstieude.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_dskhdat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            contextMenu = new ContextMenuStrip();
            contextMenu.Width = 500;
            contextMenu.Items.Add("Xóa", Image.FromFile(@"../../Image/xoa.JPG"), new EventHandler(Xoa_Click));
            // contextMenu.Items.Add("Cập nhật", Image.FromFile(@"../../Image/Huy.JPG "), new EventHandler(CapNhat_Click));

            this.ContextMenuStrip = contextMenu;


        }

        void Xoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgv_dskhdat.Rows[vitrikh];
            int idkh = Convert.ToInt32(row.Cells[0].Value.ToString());
            //ePhieuDatTruoc pdt = new ePhieuDatTruoc();
            phieuDatTruocBUL.DeletPDTByIdKH(idkh);
            MessageBox.Show("Đã hủy thành công !");


        }

        private void DatTruoc_Load(object sender, EventArgs e)
        {
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
                txtsocm.Text = kh.soCMND;
            }

        }
        public void Cleadrr()
        {
            txt_tenkh.Text = "";
            txt_sdt.Text = "";
            txtsocm.Text = "";
        }
        private void btn_dat_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgv_dstieude.Rows[vitri];
            //Ma tieu de
            int s = Convert.ToInt32(row.Cells[0].Value.ToString());
            ePhieuDatTruoc pdt = new ePhieuDatTruoc();
            int id = Convert.ToInt32(txt_idkh.Text);

            eKhachHang kh = khachHangBUL.Find(id);
            if (kh != null)
            {
                eDVD dvd = dVDBUL.getDVDOnShelf(s);
                if (dvd != null)
                {
                    pdt.id_DVD = dvd.id_DVD;
                    pdt.id_TieuDe = s;
                    pdt.ngayDatTruoc = DateTime.Today;
                    pdt.id_KhachHang = kh.id_KhachHang;
                    pdt.trangThai = 0;
                    phieuDatTruocBUL.Save(pdt);
                    MessageBox.Show("Đặt trước thành công");

                    dVDBUL.UpdateTrangThaiDVD(dvd.id_DVD, 0);
                }
                else
                {
                    pdt.id_TieuDe = s;
                    pdt.ngayDatTruoc = DateTime.Today;
                    pdt.id_KhachHang = kh.id_KhachHang;
                    pdt.trangThai = 0;
                    phieuDatTruocBUL.Save(pdt);
                    MessageBox.Show("Đặt trước thành công");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng");
                return;
            }
            dgv_dstieude.DataSource = tieuDeBUL.getTieuDes();
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
                txtsocm.Text = row.Cells[2].Value.ToString();
                txt_sdt.Text = row.Cells[3].Value.ToString();
            }
            vitrikh = e.RowIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<eTieuDe> list = tieuDeBUL.getTieuDes();
            List<eTieuDe> lit = new List<eTieuDe>();
            foreach (var i in list)
            {
                if (txtTenTua.Text.Equals(i.tenTieuDe))
                {
                    //datagridviewrow row = this.dgv_dstieude.rows[0];
                    ////đưa dữ liệu vào textbox
                    //row.cells[0].value = i.id_tieude.tostring();
                    //row.cells[1].value = i.tentieude;
                    //row.cells[2].value = i.id_theloai;
                    lit.Add(i);
                    dgv_dstieude.DataSource = lit;

                }

            }

        }

        private void txtTenTua_TextChanged(object sender, EventArgs e)
        {

            List<string> list = new List<string>();
            //List<eTieuDe> lst = tieuDeBUL.getTieuDes();
            foreach (var i in tieuDeBUL.getTieuDes().Select(a => a.tenTieuDe))
            {
                list.Add(i);
            }
            txtTenTua.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTenTua.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenTua.AutoCompleteCustomSource.AddRange(list.ToArray());
        }

        private void dgv_dskhdat_ContextMenuStripChanged(object sender, EventArgs e)
        {
            Button btnxoa = new Button();
            Button btnhuy = new Button();

        }
    }
}
