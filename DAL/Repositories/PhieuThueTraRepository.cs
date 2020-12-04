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
             return context.phieuthuetras.Where(x => x.id_KhachHang == idKH && x.ngayTra == null).ToList();
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
