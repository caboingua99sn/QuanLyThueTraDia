using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CodeFirst;
using DAL.Repositories;
using Entity;

namespace BULL
{
    public class PhieuDatTruocBUL
    {
        PhieuDatTruocRepository pdtdal;
        public PhieuDatTruocBUL()
        {
            pdtdal = new PhieuDatTruocRepository();
        }

        public List<ePhieuDatTruoc> getPhieuDatTruocs()
        {
            List<ePhieuDatTruoc> list = new List<ePhieuDatTruoc>();
            foreach (var item in pdtdal.getPhieuDatTruocs())
            {
                ePhieuDatTruoc tam = new ePhieuDatTruoc();
                tam.id_DVD = item.id_DVD;
                tam.id_TieuDe = item.id_TieuDe;
                tam.id_PhieuDatTruoc = item.id_PhieuDatTruoc;
                tam.id_KhachHang = item.id_KhachHang;
                tam.ngayDatTruoc = item.ngayDatTruoc;

                list.Add(tam);
            }
            return list;
        }

        public List<ePhieuDatTruoc> GetPhieuDatTruocsByDvdNull()
        {
            List<ePhieuDatTruoc> list = new List<ePhieuDatTruoc>();
            foreach (var item in pdtdal.getPhieuDatTruocs())
            {
                ePhieuDatTruoc tam = new ePhieuDatTruoc();
                tam.id_TieuDe = item.id_TieuDe;
                tam.id_PhieuDatTruoc = item.id_PhieuDatTruoc;
                tam.id_KhachHang = item.id_KhachHang;
                tam.ngayDatTruoc = item.ngayDatTruoc;

                list.Add(tam);
            }
            return list;
        }

        public int Update(int id_phieu, int id_dvd)
        {
            return pdtdal.Update(id_phieu, id_dvd);
        }

        public int DeletePDTByIDPhieu_IDTieuDe(int idphieu)
        {
            return pdtdal.DeletePDTByIDPhieu_IDTieuDe(idphieu);
        }

        public ePhieuDatTruoc GetPhieuDatTruocByID(int id_dvd)
        {
            PhieuDatTruoc phieu = pdtdal.GetPhieuDatTruocByID(id_dvd);
            ePhieuDatTruoc tam = new ePhieuDatTruoc();
            tam.id_DVD = phieu.id_DVD;
            tam.id_TieuDe = phieu.id_TieuDe;
            tam.id_PhieuDatTruoc = phieu.id_PhieuDatTruoc;
            tam.id_KhachHang = phieu.id_KhachHang;
            tam.ngayDatTruoc = phieu.ngayDatTruoc;
            tam.trangThai = phieu.trangThai;
            return tam;
        }

        public eTieuDe FindTieuDeById(int id)
        {
            TieuDe d = pdtdal.FindTieuDeById(id);
            eTieuDe tam = new eTieuDe();
            tam.id_TieuDe = d.id_TieuDe;
            tam.tenTieuDe = d.tenTieuDe;
            tam.id_TheLoai = d.id_TheLoai;
            return tam;

        }

        public eKhachHang FindKHBYID(int id)
        {
            KhachHang kh = pdtdal.FindKHBYID(id);
            eKhachHang tam = new eKhachHang();
            tam.id_KhachHang = kh.id_KhachHang;
            tam.tenKhachHang = kh.tenKhachHang;
            tam.soCMND = kh.soCMND;
            tam.soDT = kh.soDT;
            return tam;
        }

        public void Save(ePhieuDatTruoc p)
        {
            PhieuDatTruoc pdt = new PhieuDatTruoc();
            pdt.id_DVD = p.id_DVD;
            pdt.id_TieuDe = p.id_TieuDe;
            pdt.id_PhieuDatTruoc = p.id_PhieuDatTruoc;
            pdt.id_KhachHang = p.id_KhachHang;
            pdt.ngayDatTruoc = p.ngayDatTruoc;

            pdtdal.Save(pdt);

        }

        public List<eKhachHang> FindKhachHangById(int id)
        {
            List<KhachHang> lst = pdtdal.FindKhachHangById(id);
            List<eKhachHang> lit = new List<eKhachHang>();
            foreach (var item in lst)
            {

                eKhachHang e = new eKhachHang();
                e.id_KhachHang = item.id_KhachHang;
                e.tenKhachHang = item.tenKhachHang;
                e.soCMND = item.soCMND;
                e.soDT = item.soDT;
                lit.Add(e);
            }
            return lit;
        }

        public int DeletPDTByIdKH(int id)
        {
            pdtdal.DeletePDTByIDKH(id);
            return 1;
        }
    }
}
