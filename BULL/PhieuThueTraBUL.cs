using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CodeFirst;
using Entity;
using DAL;

namespace BULL
{
    public class PhieuThueTraBUL
    {
        PhieuThueTraRepository phieuThuTraDal;
        
        public PhieuThueTraBUL()
        {
            phieuThuTraDal = new PhieuThueTraRepository();
        }

        public List<ePhieuThueTra> getPhieuThueTraByKH(int id_KH)
        {
            List<ePhieuThueTra> list = new List<ePhieuThueTra>();
            foreach (var phieu in phieuThuTraDal.getPhieuThueTraByKH(id_KH))
            {
                ePhieuThueTra item = new ePhieuThueTra();
                item.id_KhachHang = phieu.id_KhachHang;
                item.id_DVD = phieu.id_DVD;
                item.id_PhieuThue = phieu.id_PhieuThue;
                item.ngayThue = phieu.ngayThue;
                item.ngayTra = phieu.ngayTra;
                list.Add(item);
            }
            return list;
        }

        public ePhieuThueTra getPhieuThueTraByIdDVD(int id_dvd)
        {
            PhieuThueTra phieu = phieuThuTraDal.getPhieuThueTraByIdDVD(id_dvd);
            if (phieu != null)
            {
                ePhieuThueTra item = new ePhieuThueTra();
                item.id_KhachHang = phieu.id_KhachHang;
                item.id_DVD = phieu.id_DVD;
                item.id_PhieuThue = phieu.id_PhieuThue;
                item.ngayThue = phieu.ngayThue;
                item.ngayTra = phieu.ngayTra;
                return item;
            }
            return null;
        }

        public int AddPhieuThue(int id_dvd, int id_kh, DateTime now)
        {
            return phieuThuTraDal.AddPhieuThue(id_dvd, id_kh, now);
        }

        public int UpdatePhieuThue(int id_phieu, DateTime now, DateTime ngayTreHen, double phiTrehen)
        {
            return phieuThuTraDal.UpdatePhieuThue(id_phieu, now, ngayTreHen, phiTrehen);
        }

        public int UpdatePhieuThue_Tre(int id_phieu, DateTime now, double phiTrehen)
        {
            return phieuThuTraDal.UpdatePhieuThue_Tre(id_phieu, now, phiTrehen);
        }
    }
}
