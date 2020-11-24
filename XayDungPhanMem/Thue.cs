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

namespace XayDungPhanMem
{
    public partial class frmThue : Form
    {
        PhiTreHenBUL treHenbul = new PhiTreHenBUL();
        KhachHangBUL khbul = new KhachHangBUL();
        const double PHI_TRE_HEN = 0.1;

        public frmThue()
        {
            InitializeComponent();
        }

        private void btn_tkID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_ID.Text);
            eKhachHang kh = khbul.GetKhachHangByID(id);
            txt_ten.Text = kh.tenKhachHang;
            txt_sdt.Text = kh.soDT;
            txt_cmnd.Text = kh.soCMND;
            double totalPhiTreHen = treHenbul.getTotalPhiTreHen(kh.id_KhachHang, PHI_TRE_HEN);
            if (totalPhiTreHen == 0)
            {
                return;
            }
                //L
            //Dialog thông báo còn đĩa chưa trả nếu khách muốn trả thì qua form trả nếu không tiếp tục thuê đĩa
        }
    }
}
