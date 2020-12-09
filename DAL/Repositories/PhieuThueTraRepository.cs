using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CodeFirst;

namespace DAL
{
    public class PhieuThueTraRepository
    {
        private DataContext context = new DataContext();

        private bool disposedValue = false; // To detect redundant calls

        public List<PhieuThueTra> getPhieuThueTraByKH(int idKH)
        {
            var list = context.phieuthuetras.Where(x => x.id_KhachHang == idKH && x.ngayTra == null).ToList();
             return list;
        }

        public PhieuThueTra getPhieuThueTraByIdDVD(int id_dvd)
        {
            return context.phieuthuetras.Where(x => x.id_DVD == id_dvd && x.ngayTra == null).FirstOrDefault();
        }

        public int AddPhieuThue(int id_dvd, int id_kh, DateTime now)
        {
            PhieuThueTra p = new PhieuThueTra();
            p.id_DVD = id_dvd;
            p.id_KhachHang = id_kh;
            p.ngayThue = now;
            context.phieuthuetras.Add(p);
            return context.SaveChanges();
        }

        public int UpdatePhieuThue(int id_phieu, DateTime now, DateTime ngayTreHen, double phiTrehen)
        {
            PhieuThueTra phieu = context.phieuthuetras.Where(x => x.id_PhieuThue == id_phieu).FirstOrDefault();
            phieu.ngayTra = now;
            phieu.ngayTraPhiTreHen = ngayTreHen;
            phieu.phiTreHan = phiTrehen;
            return context.SaveChanges();
        }

        public double total(int id)
        {
            List<PhieuThueTra> ls = context.phieuthuetras.Where(x => x.id_KhachHang == id && x.ngayTra != null).ToList();
            double s = 0;
            foreach (var item in ls)
            {
                if (item.ngayTraPhiTreHen == null)
                {
                    s = (double)(s + item.phiTreHan);
                }
            }
            return s;
        }

        public int UpdatePhieuThue_Tre(int id_phieu, DateTime now, double phiTrehen)
        {
            PhieuThueTra phieu = context.phieuthuetras.Where(x => x.id_PhieuThue == id_phieu).FirstOrDefault();
            phieu.ngayTra = now;
            phieu.phiTreHan = phiTrehen;
            return context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && context != null)
                {
                    context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
