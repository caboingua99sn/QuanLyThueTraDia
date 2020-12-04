using DAL.CodeFirst;
using DAL.Repositories;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULL
{
    public class TieuDeBUL
    {
        TieuDeRepository tddal;

        public TieuDeBUL()
        {
            tddal = new TieuDeRepository();
        }

        public List<eTieuDe> getTieuDes()
        {
            List<eTieuDe> list = new List<eTieuDe>();
            foreach (var item in tddal.getTieuDes())
            {
                eTieuDe tam = new eTieuDe();
                tam.id_TieuDe = item.id_TieuDe;
                tam.tenTieuDe = item.tenTieuDe;
                tam.id_TheLoai = item.id_TheLoai;
                list.Add(tam);
            }
            return list;
        }

        public List<eTieuDe> getTieuDeByTen(string ten)
        {
            List<eTieuDe> list = new List<eTieuDe>();
            foreach (var item in tddal.getListbyTenTieuDe(ten))
            {
                eTieuDe tam = new eTieuDe();
                tam.id_TieuDe = item.id_TieuDe;
                tam.tenTieuDe = item.tenTieuDe;
                tam.id_TheLoai = item.id_TheLoai;
                list.Add(tam);
            }
            return list;
        }

        public int Save(eTieuDe item)
        {
            TieuDe tam = new TieuDe();
            tam.tenTieuDe = item.tenTieuDe;
            tam.id_TheLoai = item.id_TheLoai;
            tddal.Save(tam);
            return 1;
        }

        public eTieuDe GetTieuDeByID(int id)
        {
            eTieuDe tam = new eTieuDe();
            TieuDe item = tddal.Find(id);
            if (item != null)
            {
                tam.id_TieuDe = item.id_TieuDe;
                tam.tenTieuDe = item.tenTieuDe;
                tam.id_TheLoai = item.id_TheLoai;
                return tam;
            }
            return null;
        }

        public List<eTieuDe> GetTieuDeByIDTL(int id)
        {
            List<eTieuDe> ls = new List<eTieuDe>();
            List<TieuDe> item = tddal.FindbyIDTheLoai(id);
            if (item != null)
            {
                foreach (var i in item)
                {
                    eTieuDe tam = new eTieuDe();
                    tam.id_TieuDe = i.id_TieuDe;
                    tam.tenTieuDe = i.tenTieuDe;
                    tam.id_TheLoai = i.id_TheLoai;
                    ls.Add(tam);
                }
                return ls;
            }
            return null;
        }

        public eTieuDe Find(int id)
        {
            TieuDe t = tddal.Find(id);
            eTieuDe e = new eTieuDe();
            e.id_TieuDe = t.id_TieuDe;
            e.tenTieuDe = t.tenTieuDe;
            e.id_TheLoai = t.id_TheLoai;
            return e;
        }

        public List<ePhieuDatTruoc> FindPhieuDatTruocByidTieuDe(int id)
        {
            List<PhieuDatTruoc> lst = tddal.FindPhieuDatTruocByidTieuDe(id);
            List<ePhieuDatTruoc> lit = new List<ePhieuDatTruoc>();
            foreach (var item in lst)
            {
                ePhieuDatTruoc e = new ePhieuDatTruoc();
                e.id_DVD = item.id_DVD;
                e.id_TieuDe = item.id_TieuDe;
                e.id_PhieuDatTruoc = item.id_PhieuDatTruoc;
                e.id_KhachHang = item.id_KhachHang;
                e.ngayDatTruoc = item.ngayDatTruoc;
                lit.Add(e);
            }
            return lit;
        }

        public ePhieuDatTruoc FindbyID(int id)
        {
            PhieuDatTruoc p = tddal.FindbyID(id);
            ePhieuDatTruoc tam = new ePhieuDatTruoc();
            tam.id_DVD = p.id_DVD;
            tam.id_TieuDe = p.id_TieuDe;
            tam.id_PhieuDatTruoc = p.id_PhieuDatTruoc;
            tam.id_KhachHang = p.id_KhachHang;
            tam.ngayDatTruoc = p.ngayDatTruoc;
            return tam;
        }

        public eTheLoai FindTheLoaiById(int id)
        {
            TheLoai t = tddal.FindTheLoaiById(id);
            if (t != null)
            {
                eTheLoai e = new eTheLoai();

                e.id_TheLoai = t.id_TheLoai;
                e.tenTheLoai = t.tenTheLoai;
                e.giaThue = t.giaThue;
                e.thoiGianThue = t.thoiGianThue;
                return e;
            }
            return null;

        }

        public int Delete(int idxoa)
        {
            tddal.Delete(idxoa);
            return 1;
        }
    }
}