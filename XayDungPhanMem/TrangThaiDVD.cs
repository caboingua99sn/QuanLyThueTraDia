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
    public partial class TrangThaiDVD : Form
    {

        DVDBUL dVDBUL = new DVDBUL();
        PhieuDatTruocBUL phieuDatTruocBUL = new PhieuDatTruocBUL();
        PhieuThueTraBUL phieuThueTraBUL = new PhieuThueTraBUL();
        KhachHangBUL khachHangBUL = new KhachHangBUL();
        TieuDeBUL tieuDeBUL = new TieuDeBUL();
        TheLoaiBUL theLoaiBUL = new TheLoaiBUL();

        public TrangThaiDVD()
        {
            InitializeComponent();
            this.Size = new Size(319, 79);
            lblTieuDe1.Visible = false;
            lblTrangThai1.Visible = false;
            lblTieuDe.Visible = false;
            lblTrangThai.Visible = false;
            grThue.Visible = false;
            grCho.Visible = false;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!txtIDdia.Text.ToString().Trim().Equals(""))
            {
                eDVD dvd = dVDBUL.FindDVDById(Convert.ToInt32(txtIDdia.Text.ToString()));
                if (dvd != null)
                {
                    this.Size = new Size(319, 137);
                    lblTieuDe1.Visible = true;
                    lblTrangThai1.Visible = true;
                    lblTieuDe.Visible = true;
                    lblTrangThai.Visible = true;
                    lblTieuDe.Text = tieuDeBUL.Find(dvd.id_TieuDe).tenTieuDe;
                    if (dvd.trangThai == -1)
                    {
                        lblTrangThai.Text = "Trên kệ";
                    }
                    else if (dvd.trangThai == 0)
                    {
                        this.Size = new Size(319, 223);
                        grCho.Visible = true;
                        grThue.Visible = false;
                        lblTrangThai.Text = "Đang giữ";
                        ePhieuDatTruoc phieu = phieuDatTruocBUL.GetPhieuDatTruocByID(dvd.id_DVD);
                        lblNguoiDatTrc.Text = khachHangBUL.Find(phieu.id_KhachHang).tenKhachHang;
                        lblNgayLay.Text = phieu.ngayDatTruoc.ToShortDateString();
                    }
                    else
                    {
                        this.Size = new Size(319, 223);
                        grThue.Visible = true;
                        grCho.Visible = false;
                        lblTrangThai.Text = "Đang thuê";
                        ePhieuThueTra phieu = phieuThueTraBUL.getPhieuThueTraByIdDVD(dvd.id_DVD);
                        if (phieu != null)
                        {
                            lblNguoiThue.Text = khachHangBUL.Find(phieu.id_KhachHang).tenKhachHang;
                            int tgianThue = theLoaiBUL.GetTheLoaiByID(tieuDeBUL.Find(dvd.id_TieuDe).id_TheLoai).thoiGianThue;
                            DateTime ngayTraDuKien = phieu.ngayThue.AddDays(tgianThue);
                            lblDenHan.Text = ngayTraDuKien.ToShortDateString();
                        }
                    }
                }
                else
                {
                    this.Size = new Size(319, 79);
                    grThue.Visible = false;
                    grCho.Visible = false;
                    lblTieuDe1.Visible = false;
                    lblTrangThai1.Visible = false;
                    lblTieuDe.Visible = false;
                    lblTrangThai.Visible = false;
                    MessageBox.Show("Không tồn tại DVD");
                    return;
                }
            }
        }
    }
}
