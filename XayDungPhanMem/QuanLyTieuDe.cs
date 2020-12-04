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
    public partial class QuanLyTieuDe : Form
    {
        TieuDeBUL tdbul;
        TheLoaiBUL tlbul;
        int maTheLoai = 1;
        public QuanLyTieuDe()
        {
            InitializeComponent();
        }

        private void QuanLyTieuDe_Load(object sender, EventArgs e)
        {
            txt_id.ReadOnly = true;
            cbb_tl.Enabled = false;
            txt_time.ReadOnly = true;
            txt_ten.ReadOnly = true;
            txt_Gia.ReadOnly = true;
            btnhuy.Visible = false;
            ///
            tdbul = new TieuDeBUL();
            tlbul = new TheLoaiBUL();
            ///Load Tieu De
            treeView1.Nodes.Clear();
            foreach (eTheLoai td in tlbul.getTheLoais())
            {
                TreeNode n = new TreeNode(td.tenTheLoai);
                n.Tag = td.id_TheLoai;
                treeView1.Nodes.Add(n);
            }
            ///combobox
            /*cbb_tl.DataSource = tlbul.getTheLoais();
            cbb_tl.DisplayMember = "tenTheLoai";*/
            foreach (eTheLoai td in tlbul.getTheLoais())
                cbb_tl.Items.Add(td.tenTheLoai);
            cbb_tl.SelectedIndex = 0;
        }
        void FormatLaiDataGridview(DataGridView dgv)
        {
            dgv.Columns["id_TieuDe"].HeaderText = "Mã Tiêu Đề";
            dgv.Columns["tenTieuDe"].Width = 150;
            dgv.Columns["tenTieuDe"].HeaderText = "Tên Tiêu Đề";
            dgv.Columns["id_TheLoai"].Visible = false;
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int strMa;
            List<eTieuDe> ls = new List<eTieuDe>();
            if (treeView1.SelectedNode != null)
            {
                eTheLoai tl = new eTheLoai();
                tl = tlbul.GetTheLoaiByID(Convert.ToInt32(treeView1.SelectedNode.Tag.ToString()));
                txt_time.Text = tl.thoiGianThue.ToString();
                txt_Gia.Text = tl.giaThue.ToString();

                /// ds tieu de
                strMa = Convert.ToInt32(treeView1.SelectedNode.Tag.ToString());
                ls = tdbul.GetTieuDeByIDTL(strMa);
                dgv_tieude.DataSource = ls;
                FormatLaiDataGridview(dgv_tieude);
                //combobox
                cbb_tl.SelectedItem = tl.tenTheLoai;
            }
        }

        private void dgv_tieude_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgv_tieude.SelectedRows.Count > 0)
            {
                txt_id.Text = e.Row.Cells["id_TieuDe"].Value.ToString();
                txt_ten.Text = e.Row.Cells["tenTieuDe"].Value.ToString();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {

            if (btn_them.Text.Equals("Thêm"))
            {
                btn_them.Text = "Lưu";
                txt_ten.ReadOnly = false;
                btnhuy.Visible = true;
                txt_id.Text = "";
                cbb_tl.Enabled = true;
            }
            else
            {
                if (txt_ten.Text.Equals(""))
                    MessageBox.Show("Ten khong duoc de trong");
                else
                {
                    eTieuDe td = new eTieuDe();
                    td.tenTieuDe = txt_ten.Text;
                    td.id_TheLoai = maTheLoai;
                    if (tdbul.Save(td) == 1)
                    {
                        MessageBox.Show("Them Thanh Cong");
                        btn_them.Text = "Thêm";
                        txt_ten.ReadOnly = true;
                        btnhuy.Visible = false;
                        cbb_tl.Enabled = true;
                        txt_id.Text = "";
                    }
                    else
                        MessageBox.Show("Them that bai");
                }
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btn_them.Text = "Thêm";
            txt_ten.ReadOnly = true;
            txt_ten.Text = "";
            btnhuy.Visible = false;
            cbb_tl.Enabled = true;
        }

        private void cbb_tl_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (eTheLoai td in tlbul.getTheLoais())
            {
                if (cbb_tl.SelectedItem.Equals(td.tenTheLoai))
                    maTheLoai = td.id_TheLoai;
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (!txt_id.Text.Equals(""))
            {
                if (tdbul.Delete(Convert.ToInt32(txt_id.Text)) == 1)
                    MessageBox.Show("Xoa Thanh Cong");
                else MessageBox.Show("Xoa That Bai");
            }
            else MessageBox.Show("Chua chon tieu de can xoa");
        }
    }
}
