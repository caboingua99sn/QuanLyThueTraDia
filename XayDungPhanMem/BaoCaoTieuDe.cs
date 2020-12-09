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
    public partial class BaoCaoTieuDe : Form
    {
        TieuDeBUL tdbul;
        TheLoaiBUL tlbul;
        PhieuDatTruocBUL pdt;
        PhieuThueTraBUL ptt;
        DVDBUL dvd;
        public BaoCaoTieuDe()
        {
            InitializeComponent();
        }

        private void BaoCaoTieuDe_Load(object sender, EventArgs e)
        {
            tdbul = new TieuDeBUL();
            tlbul = new TheLoaiBUL();
            pdt = new PhieuDatTruocBUL();
            ptt = new PhieuThueTraBUL();
            dvd = new DVDBUL();

            treeView1.Nodes.Clear();
            foreach (eTheLoai td in tlbul.getTheLoais())
            {
                TreeNode n = new TreeNode(td.tenTheLoai);
                n.Tag = td.id_TheLoai;
                treeView1.Nodes.Add(n);
            }
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
            }
        }
        private void loadtext(int id)
        {
            List<eDVD> dv = dvd.getDVDs().Where(x => x.id_TieuDe == id).ToList();
            txt_tbs.Text = dv.Count().ToString();
            int i = 0, j = 0, k = 0, z = 0;
            foreach (var item in dv)
            {
                if (item.trangThai == 1)
                    i++;
                else if (item.trangThai == -1)
                    j++;
            }
            List<ePhieuDatTruoc> lsdt = pdt.getPhieuDatTruocs();
            foreach (var item in dv)
            {
                if (lsdt.Where(x => x.id_DVD == item.id_DVD).FirstOrDefault() != null)
                    k++;
            }
            foreach (var item in dv)
            {
                z = z + lsdt.Where(x => x.id_DVD == item.id_DVD).ToList().Count();
            }
            txt_dcthue.Text = i.ToString();
            txt_dattruoc.Text = k.ToString();
            txt_kho.Text = j.ToString();
            txt_dtchoxuly.Text = z.ToString();


        }

        private void dgv_tieude_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgv_tieude.SelectedRows.Count > 0)
            {
                txt_id.Text = e.Row.Cells["id_TieuDe"].Value.ToString();
                txt_ten.Text = e.Row.Cells["tenTieuDe"].Value.ToString();
                loadtext((int)e.Row.Cells["id_TieuDe"].Value);
            }
        }
    }
}
