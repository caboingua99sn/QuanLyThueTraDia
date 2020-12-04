using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

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
            foreach (var item in phieuThuTraDal.getPhieuThueTraByKH(id_KH))
            {
                ePhieuThueTra phieu = new ePhieuThueTra();
                item.id_KhachHang = phieu.id_KhachHang;
                item.id_DVD = phieu.id_DVD;
                item.id_PhieuThue = phieu.id_PhieuThue;
                item.ngayThue = phieu.ngayThue;
                item.ngayTra = phieu.ngayTra;
                list.Add(phieu);
            }
            return list;
        }

        public int AddPhieuThue(int id_dvd, int id_kh, DateTime now)
        {
            return phieuThuTraDal.AddPhieuThue(id_dvd, id_kh, now);
        }
    }
}
