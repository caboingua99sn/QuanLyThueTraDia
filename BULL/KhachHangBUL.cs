using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL.CodeFirst;
using System.Data.Entity;
using DAL.Repositories;
namespace BULL
{
   public class KhachHangBUL
    {
        KhachHangRepository khdal;
        public KhachHangBUL()
        {
            khdal = new KhachHangRepository();
        }
        public List<eKhachHang> getKhachHangs()
        {
            List<eKhachHang> list = new List<eKhachHang>();
            foreach (var item in khdal.getKhachHangs())
            {
                eKhachHang tam = new eKhachHang();
                tam.id_KhachHang = item.id_KhachHang;
                tam.tenKhachHang = item.tenKhachHang;
                tam.soCMND = item.soCMND;
                tam.soDT = item.soDT;
                list.Add(tam);
            }
            return list;
        }

        public int Save(eKhachHang p)
        {
            KhachHang item = new KhachHang();
            item.id_KhachHang = p.id_KhachHang;
            item.tenKhachHang = p.tenKhachHang;
            item.soDT = p.soDT;
            item.soCMND = p.soCMND;
            khdal.Save(item);
            return 1;
        }

        public int UpdateKhachHang(eKhachHang kh)
        {
            KhachHang temp = khdal.Find(kh.id_KhachHang);
            temp.tenKhachHang = kh.tenKhachHang;
            temp.soCMND = kh.soCMND;
            temp.soDT = kh.soDT;
            khdal.Update(temp.id_KhachHang);
            return 1;
        }

        public int Delete(string idxoa)
        {
            khdal.Delete(idxoa);
            return 1;
        }

        public eKhachHang GetKhachHangByID(int idkh)
        {
            eKhachHang kh = new eKhachHang();
            KhachHang temp = khdal.Find(idkh);
            if (temp != null)
            {
                kh.tenKhachHang = temp.tenKhachHang;
                kh.soCMND = temp.soCMND;
                kh.soDT = temp.soDT;
                return kh;
            }
            return null;
        }

        public eKhachHang Find(int id)
        {
            KhachHang kh = khdal.Find(id);
            if (kh != null)
            {
                eKhachHang e = new eKhachHang();
                e.id_KhachHang = kh.id_KhachHang;
                e.tenKhachHang = kh.tenKhachHang;
                e.soDT = kh.soDT;
                e.soCMND = kh.soCMND;

                return e;
            }
            return null;
        }
    }
}
