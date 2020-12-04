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
        DVDBUL dVDBUL = new DVDBUL();
        TieuDeBUL tieuDeBUL = new TieuDeBUL();
        TheLoaiBUL tlbus = new TheLoaiBUL();
        PhieuThueTraBUL phieuTTBul = new PhieuThueTraBUL();
        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        List<eDVD> listThue = new List<eDVD>();
        List<eDVD> listDsDVD = new List<eDVD>();
        List<ePhieuThueTra> listPhieuPhiTreHenTruoc = new List<ePhieuThueTra>();
        List<ePhieuThueTra> listPhieuPhiTreHenSau = new List<ePhieuThueTra>();
        double phiThue = 0;
        double phiTreHen = 0;
        double tongPhi = 0;
        int idkh = 0;

        public frmThue()
        {
            InitializeComponent();
            dgvDSDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void LoadData(DataGridView dgv, List<eDVD> list)
        {
            AutoComplete();
            dgv.DataSource = ConvertListToDataTable(list);
            FormatGridView(dgv);
        }

        private void frmThue_Load(object sender, EventArgs e)
        {
            List<eDVD> list = dVDBUL.getDVDsByTrangThai(-1);   // -1 là onshelf
            listDsDVD.Clear();
            listDsDVD = list;
            LoadData(dgvDSDia, list);
        }

        private void CheckDsTreHen()
        {
            if (idkh != 0)
            {
                List<ePhieuThueTra> list = treHenbul.getListPhiTreHen(idkh);
                listPhieuPhiTreHenTruoc = list;
                dgvallphitrehan.DataSource = ConvertListToDataTableTreHan(list);
                FormatGridViewTrehan(dgvallphitrehan);
            }
        }

        private DataTable ConvertListToDataTableTreHan(List<ePhieuThueTra> list)
        {
            DataTable table_PhiTreHen = new DataTable();
            table_PhiTreHen.Columns.Add("id_PhieuThue", typeof(int));
            table_PhiTreHen.Columns.Add("id_DVD", typeof(int));
            table_PhiTreHen.Columns.Add("ngayThue", typeof(string));
            table_PhiTreHen.Columns.Add("ngayTra", typeof(string));
            table_PhiTreHen.Columns.Add("phiTreHan", typeof(double));
            foreach (ePhieuThueTra item in list)
            {
                double phiThue = tlbus.GetTheLoaiByID(tieuDeBUL.GetTieuDeByID(dVDBUL.FindDVDById(item.id_DVD).id_TieuDe).id_TheLoai).giaThue;
                table_PhiTreHen.Rows.Add(item.id_PhieuThue, item.id_DVD, item.ngayThue.ToString(), item.ngayTra.ToString(), phiThue * PHI_TRE_HEN);
            }
            return table_PhiTreHen;
        }

        private void FormatGridViewTrehan(DataGridView dgv)
        {
            dgv.Columns["id_PhieuThue"].HeaderText = "Mã phiếu";
            dgv.Columns["id_DVD"].HeaderText = "Mã DVD";
            dgv.Columns["ngayThue"].HeaderText = "Ngày thuê";
            dgv.Columns["ngayTra"].HeaderText = "Ngày trả";
            dgv.Columns["phiTreHan"].HeaderText = "Phí trễ hạn";

            //set kích thước cột
            dgv.Columns["id_PhieuThue"].Width = 40;
            dgv.Columns["id_DVD"].Width = 40;
            dgv.Columns["ngayThue"].Width = 130;
            dgv.Columns["ngayTra"].Width = 130;
            dgv.Columns["phiTreHan"].Width = 60;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvphitrehanthanhtoan.DataSource = null;
            if (txt_ID.Text.Trim().Equals(""))
            {
                MessageBox.Show("Không được để rỗng");
                txt_ID.Focus();
                return;
            }
            eKhachHang kh = new eKhachHang();
            kh = khbul.Find(Convert.ToInt32(txt_ID.Text.Trim()));
            if (kh != null)
            {
                idkh = kh.id_KhachHang;
                txt_ten.Text = kh.tenKhachHang;
                txt_cmnd.Text = kh.soCMND;
                txt_sdt.Text = kh.soDT;
                CheckDsTreHen();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không tồn tài khách hàng. Bạn có muốn thêm khách hàng?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    QuanLyKhachHang frm = new QuanLyKhachHang();    // xử lí sau
                    frm.Show();
                }
            }
        }

        private DataTable ConvertListToDataTable(List<eDVD> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add("id_DVD", typeof(int));
            table.Columns.Add("id_TieuDe", typeof(int));
            table.Columns.Add("string_TieuDe", typeof(string));
            table.Columns.Add("gia", typeof(string));
            table.Columns.Add("thoigian", typeof(string));

            foreach (eDVD item in list)
            {
                eTheLoai theLoai = tieuDeBUL.FindTheLoaiById(tieuDeBUL.Find(item.id_TieuDe).id_TheLoai);
                table.Rows.Add(item.id_DVD, item.id_TieuDe, tieuDeBUL.GetTieuDeByID(item.id_TieuDe).tenTieuDe, theLoai.giaThue, theLoai.thoiGianThue);
            }
            return table;
        }

        void FormatGridView(DataGridView dgv)
        {
            dgv.Columns["id_TieuDe"].Visible = false;
            dgv.Columns["id_DVD"].HeaderText = "ID";
            dgv.Columns["string_TieuDe"].HeaderText = "Tiêu đề";
            dgv.Columns["gia"].HeaderText = "Giá thuê";
            dgv.Columns["thoigian"].HeaderText = "Thời gian thuê";

            //set kích thước cột
            dgv.Columns["id_DVD"].Width = 40;
            dgv.Columns["string_TieuDe"].Width = 180;
            dgv.Columns["gia"].Width = 60;
            dgv.Columns["thoigian"].Width = 60;

            //set thứ tự cột
            dgv.Columns["id_DVD"].DisplayIndex = 0;
            dgv.Columns["id_TieuDe"].DisplayIndex = 2;
            dgv.Columns["gia"].DisplayIndex = 3;
            dgv.Columns["thoigian"].DisplayIndex = 4;
        }

        private void btnCapNhatKH_Click(object sender, EventArgs e)
        {

        }

        private void AutoComplete()
        {
            foreach (eTieuDe item in tieuDeBUL.getTieuDes())
            {
                coll.Add(item.tenTieuDe);
            }
            txt_tendia.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_tendia.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_tendia.AutoCompleteCustomSource = coll;
        }

        private void btn_tkDia_Click(object sender, EventArgs e)
        {
            if (!txt_IDDia.Text.Trim().Equals(""))
            {
                listDsDVD.Clear();
                List<eDVD> list = new List<eDVD>();
                eDVD dvd = dVDBUL.FindDVDById(Convert.ToInt32(txt_IDDia.Text.Trim()));
                if (dvd != null)
                {
                    list.Add(dvd);
                    LoadData(dgvDSDia, list);
                }
                listDsDVD = list;
            }
            if (!txt_tendia.Text.Trim().Equals(""))
            {
                listDsDVD.Clear();
                List<eDVD> listDVD = new List<eDVD>();
                List<eTieuDe> list = tieuDeBUL.getTieuDeByTen(txt_tendia.Text.Trim());
                foreach (eTieuDe item in list)
                {
                    listDVD = dVDBUL.getDVDsByTieuDe(item.id_TieuDe);
                }
                LoadData(dgvDSDia, listDVD);
                listDsDVD = listDVD;
            }
        }

        private void btn_thue_Click(object sender, EventArgs e)
        {
            // add dvd to grid view
            foreach (DataGridViewRow row in dgvDSDia.SelectedRows)
            {
                if (!row.Cells[0].Value.ToString().Equals(""))
                {
                    int iddia = Convert.ToInt32(row.Cells[0].Value.ToString());
                    int id_tieude = Convert.ToInt32(row.Cells[1].Value.ToString());
                    eDVD dvd = new eDVD();
                    dvd.id_DVD = iddia;
                    dvd.id_TieuDe = id_tieude;
                    dvd.trangThai = -1;
                    dgvDSDia.Rows.Remove(row);
                    foreach (eDVD item in listDsDVD)
                    {
                        if (iddia == item.id_DVD)
                        {
                            listDsDVD.Remove(item);
                            break;
                        }
                    }
                    phiThue += Convert.ToInt32(tlbus.GetTheLoaiByID(tieuDeBUL.Find(id_tieude).id_TheLoai).giaThue);
                    tongPhi = phiThue + phiTreHen;
                    listThue.Add(dvd);
                }
            }
            dsDiaThue.DataSource = ConvertListToDataTable(listThue);
            FormatGridViewDiaThue(dsDiaThue);
            txtPhiThue.Text = phiThue.ToString();
            txtTong.Text = tongPhi.ToString();
        }

        private void FormatGridViewDiaThue(DataGridView dgv)
        {
            dgv.Columns["id_TieuDe"].Visible = false;
            dgv.Columns["id_DVD"].HeaderText = "ID";
            dgv.Columns["string_TieuDe"].HeaderText = "Tiêu đề";
            dgv.Columns["gia"].HeaderText = "Giá thuê";
            dgv.Columns["thoigian"].HeaderText = "Thời gian thuê";

            //set kích thước cột
            dgv.Columns["id_DVD"].Width = 90;
            dgv.Columns["string_TieuDe"].Width = 350;
            dgv.Columns["gia"].Width = 200;
            dgv.Columns["thoigian"].Width = 200;

            //set thứ tự cột
            dgv.Columns["id_DVD"].DisplayIndex = 0;
            dgv.Columns["id_TieuDe"].DisplayIndex = 2;
            dgv.Columns["gia"].DisplayIndex = 3;
            dgv.Columns["thoigian"].DisplayIndex = 4;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dsDiaThue.SelectedRows)
            {
                if (!row.Cells[0].Value.ToString().Equals(""))
                {
                    int iddia = Convert.ToInt32(row.Cells[0].Value.ToString());
                    int id_tieude = Convert.ToInt32(row.Cells[1].Value.ToString());
                    eDVD dvd = new eDVD();
                    dvd.id_DVD = iddia;
                    dvd.id_TieuDe = id_tieude;
                    dvd.trangThai = -1;
                    dsDiaThue.Rows.Remove(row);
                    phiThue -= Convert.ToInt32(tlbus.GetTheLoaiByID(tieuDeBUL.Find(id_tieude).id_TheLoai).giaThue);
                    tongPhi = phiThue + phiTreHen;
                    listDsDVD.Add(dvd);
                    foreach (eDVD item in listThue)
                    {
                        if (iddia == item.id_DVD)
                        {
                            listThue.Remove(item);
                            break;
                        }
                    }
                }
            }
            LoadData(dgvDSDia, listDsDVD);
            txtPhiThue.Text = phiThue.ToString();
            txtTong.Text = tongPhi.ToString();
        }

        private void btn_ttphi_Click(object sender, EventArgs e)
        {
            int count = 0;
            DateTime now = DateTime.Now;
            if (idkh == 0)
            {
                MessageBox.Show("Bạn hãy đưa vào thông tin khách hàng");
                return;
            }
            if (dsDiaThue.RowCount != 0)
            {
                foreach (DataGridViewRow row in dsDiaThue.Rows)
                {
                    int id_DVD = Convert.ToInt32(row.Cells[0].Value.ToString());
                    count = phieuTTBul.AddPhieuThue(id_DVD, idkh, now);
                    if (count == 1)
                    {
                        dVDBUL.UpdateTrangThaiDVD(id_DVD, 1);   // 1 là trạng thái đang cho thuê
                    }
                }
            }
            if (dgvphitrehanthanhtoan.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvphitrehanthanhtoan.Rows)
                {
                    int id_DVD = Convert.ToInt32(row.Cells[1].Value.ToString());
                    count = treHenbul.ThanhToanPhiTreHen(idkh, id_DVD, now);
                }
            }
            if (count == 1)
            {
                MessageBox.Show("Thanh toán thành công");
                listThue.Clear();
                listPhieuPhiTreHenSau.Clear();
                dsDiaThue.DataSource = ConvertListToDataTable(listThue);
                FormatGridViewDiaThue(dsDiaThue);
                dgvphitrehanthanhtoan.DataSource = ConvertListToDataTableTreHan(listPhieuPhiTreHenSau);
                FormatGridViewTrehan(dgvphitrehanthanhtoan);
            }
        }

        private void btnnextall_Click(object sender, EventArgs e)
        {
            phiTreHen = 0;
            dgvphitrehanthanhtoan.DataSource = ConvertListToDataTableTreHan(treHenbul.getListPhiTreHen(idkh));
            FormatGridViewTrehan(dgvphitrehanthanhtoan);
            listPhieuPhiTreHenTruoc.Clear();
            dgvallphitrehan.DataSource = ConvertListToDataTableTreHan(listPhieuPhiTreHenTruoc);
            foreach (DataGridViewRow row in dgvphitrehanthanhtoan.Rows)
            {
                double phi = Convert.ToDouble(row.Cells[4].Value.ToString());
                phiTreHen += phi;
                tongPhi = phiTreHen + phiThue;
            }
            txtPhiTre.Text = phiTreHen.ToString();
            txtTong.Text = tongPhi.ToString();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvallphitrehan.SelectedRows)
            {
                ePhieuThueTra phieu = new ePhieuThueTra();
                phieu.id_PhieuThue = Convert.ToInt32(row.Cells[0].Value.ToString());
                phieu.id_DVD = Convert.ToInt32(row.Cells[1].Value.ToString());
                phieu.ngayThue = Convert.ToDateTime(row.Cells[2].Value.ToString());
                phieu.ngayTra = Convert.ToDateTime(row.Cells[3].Value.ToString());
                double phi = Convert.ToDouble(row.Cells[4].Value.ToString());
                phieu.phiTreHan = phi;
                foreach (ePhieuThueTra item in listPhieuPhiTreHenTruoc)
                {
                    if (phieu.id_PhieuThue == item.id_PhieuThue)
                    {
                        listPhieuPhiTreHenTruoc.Remove(item);
                        break;
                    }
                }
                phiTreHen += phi;
                tongPhi = phiTreHen + phiThue;
                listPhieuPhiTreHenSau.Add(phieu);
                dgvallphitrehan.Rows.Remove(row);
            }
            dgvphitrehanthanhtoan.DataSource = ConvertListToDataTableTreHan(listPhieuPhiTreHenSau);
            FormatGridViewTrehan(dgvphitrehanthanhtoan);
            txtPhiTre.Text = phiTreHen.ToString();
            txtTong.Text = tongPhi.ToString();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvphitrehanthanhtoan.SelectedRows)
            {
                ePhieuThueTra phieu = new ePhieuThueTra();
                phieu.id_PhieuThue = Convert.ToInt32(row.Cells[0].Value.ToString());
                phieu.id_DVD = Convert.ToInt32(row.Cells[1].Value.ToString());
                phieu.ngayThue = Convert.ToDateTime(row.Cells[2].Value.ToString());
                phieu.ngayTra = Convert.ToDateTime(row.Cells[3].Value.ToString());
                phieu.phiTreHan = PHI_TRE_HEN;
                double phi = Convert.ToDouble(phieu.phiTreHan) * Convert.ToDouble(tlbus.GetTheLoaiByID(tieuDeBUL.Find(dVDBUL.FindDVDById(phieu.id_DVD).id_TieuDe).id_TheLoai).giaThue);
                phiTreHen -= phi;
                tongPhi = phiTreHen + phiThue;
                foreach (ePhieuThueTra item in listPhieuPhiTreHenSau)
                {
                    if (phieu.id_PhieuThue == item.id_PhieuThue)
                    {
                        listPhieuPhiTreHenSau.Remove(item);
                        break;
                    }
                }
                listPhieuPhiTreHenTruoc.Add(phieu);
                dgvphitrehanthanhtoan.Rows.Remove(row);
            }
            dgvallphitrehan.DataSource = ConvertListToDataTableTreHan(listPhieuPhiTreHenTruoc);
            FormatGridViewTrehan(dgvallphitrehan);
            txtPhiTre.Text = phiTreHen.ToString();
            txtTong.Text = tongPhi.ToString();
        }

        private void backall_Click(object sender, EventArgs e)
        {
            phiTreHen = 0;
            dgvallphitrehan.DataSource = ConvertListToDataTableTreHan(treHenbul.getListPhiTreHen(idkh));
            FormatGridViewTrehan(dgvallphitrehan);
            listPhieuPhiTreHenSau.Clear();
            dgvphitrehanthanhtoan.DataSource = ConvertListToDataTableTreHan(listPhieuPhiTreHenSau);
            tongPhi = phiTreHen + phiThue;
            txtPhiTre.Text = phiTreHen.ToString();
            txtTong.Text = tongPhi.ToString();
        }
    }
}
