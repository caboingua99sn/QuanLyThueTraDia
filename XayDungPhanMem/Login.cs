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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void SaveSetting()
        {
            Properties.Settings.Default.useName = "admin";
            Properties.Settings.Default.passWord = "admin";
            Properties.Settings.Default.Save();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUseName.Text.ToString().Equals("admin") && txtPassWord.Text.ToString().Equals("admin"))
            {
                SaveSetting();
                MessageBox.Show("Login thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản mật khẩu không đúng");
                txtUseName.Focus();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
