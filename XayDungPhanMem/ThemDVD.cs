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
using XayDungPhanMem;


namespace XayDungPhanMem
{
    public partial class ThemDVD : Form
    {
        DVDBUL dvdbul;
        TieuDeBUL tdbul;


        public ThemDVD()
        {
            dvdbul = new DVDBUL();
            tdbul = new TieuDeBUL();
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string user = Properties.Settings.Default.useName;
            string pass = Properties.Settings.Default.passWord;
            if (user.Equals("Empty") && pass.Equals("Empty"))
            {
                Login frm = new Login();
                frm.ShowDialog();
            }
            else
            {
                if (txtSL.Text != "")
                {
                    List<eTieuDe> list = new List<eTieuDe>();
                    list = tdbul.getTieuDes();
                    eTieuDe etd = new eTieuDe();
                    etd = list.FirstOrDefault(a => a.tenTieuDe == cbbTieuDe.Text);
                    eDVD dVD = new eDVD();
                    dVD.id_TieuDe = etd.id_TieuDe;
                    dVD.trangThai = -1; //onshelf
                    for (int i = 0; i < Convert.ToInt32(txtSL.Text.Trim()); i++)
                    {
                        dvdbul.Save(dVD);
                    }
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng");
                }
            }
        }

        public void ThemDVD_Load(object sender, EventArgs e)
        {
            List<eTieuDe> list = new List<eTieuDe>();
            list = tdbul.getTieuDes();
            List<String> lt = new List<string>();
            foreach (var item in list)
            {
                lt.Add(item.tenTieuDe);
            }
            cbbTieuDe.DataSource = lt;
        }

        public void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
