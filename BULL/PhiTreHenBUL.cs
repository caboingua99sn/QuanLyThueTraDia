using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.CodeFirst;
using Entity;

namespace BULL
{
    public class PhiTreHenBUL
    {
        PhiTreHenRepository phiTreHen;

        public PhiTreHenBUL()
        {
            phiTreHen = new PhiTreHenRepository();
        }

        public List<ePhieuThueTra> getListPhiTreHen(int id_KH)
        {
            List<ePhieuThueTra> list = new List<ePhieuThueTra>();
            foreach (PhieuThueTra item in phiTreHen.getListPhiTreHen(id_KH))
            {
                ePhieuThueTra phieu = new ePhieuThueTra();
                phieu.id_DVD = item.id_DVD;
                phieu.id_KhachHang = item.id_KhachHang;
                phieu.ngayThue = item.ngayThue;
                phieu.id_PhieuThue = item.id_PhieuThue;
                phieu.ngayTra = item.ngayTra;
                list.Add(phieu);
            }
            return list;
        }

        public int ThanhToanPhiTreHen(int idkh, int dvd, DateTime now)
        {
            return phiTreHen.ThanhToanPhiTreHen(idkh, dvd, now);
        }
    }
}
