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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void quanlidia_click(object sender, EventArgs e)
        {
            bool check = CheckExistForm("frmQuanlydia");
            if (!check)
            {
                frmQuanlydia quanLyDia = new frmQuanlydia();
                quanLyDia.MdiParent = this;
                quanLyDia.Show();
            }
            else
            {
                ActiveChildForm("frmQuanlydia");
            }
        }

        private void DatTruoc(object sender, EventArgs e)
        {

            bool check = CheckExistForm("frmQuanlydia");
            if (!check)
            {
                frmDatTruoc f = new frmDatTruoc();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActiveChildForm("frmQuanlydia");
            }
        }

        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

        private void quanlykhachhang_Click(object sender, EventArgs e)
        {
            bool check = CheckExistForm("QuanLyKhachHang");
            if (!check)
            {
                QuanLyKhachHang f = new QuanLyKhachHang();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActiveChildForm("QuanLyKhachHang");
            }
        }

        private void thue_Click(object sender, EventArgs e)
        {
            bool check = CheckExistForm("frmThue");
            if (!check)
            {
                frmThue f = new frmThue();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActiveChildForm("frmThue");
            }
        }

        private void quanlytieude_Click(object sender, EventArgs e)
        {
            bool check = CheckExistForm("QuanLyTieuDe");
            if (!check)
            {
                QuanLyTieuDe f = new QuanLyTieuDe();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActiveChildForm("QuanLyTieuDe");
            }
        }

        private void tradia_Click(object sender, EventArgs e)
        {
            bool check = CheckExistForm("TraDia");
            if (!check)
            {
                TraDia f = new TraDia();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActiveChildForm("TraDia");
            }
        }
    }
}
