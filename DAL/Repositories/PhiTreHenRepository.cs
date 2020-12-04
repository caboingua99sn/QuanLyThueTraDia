using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CodeFirst;

namespace DAL.Repositories
{
    public class PhiTreHenRepository : IDisposable
    {
        private DataContext context = new DataContext();
        private bool disposedValue = false;

        public List<PhieuThueTra> getListPhiTreHen(int id_KH)
        {
            return context.phieuthuetras.Where(x => x.id_KhachHang == id_KH && (x.phiTreHan != 0 && x.phiTreHan != null)).ToList();
        }

        public int ThemPhiTreHen(int id_DVD, double phi_tre_hen)
        {
            TieuDe tieu_de = context.tieudes.Where(x => x.id_TieuDe == id_DVD).FirstOrDefault();
            TheLoai the_loai = context.theloais.Where(x => x.id_TheLoai == tieu_de.id_TheLoai).FirstOrDefault();
            PhieuThueTra phieu = context.phieuthuetras.Where(x => x.ngayTra == null).FirstOrDefault();
            if ((DateTime.Now - phieu.ngayThue).TotalDays >= the_loai.giaThue)
            {
                phieu.phiTreHan = phi_tre_hen;
                context.SaveChanges();
            }
            return 1;
        }

        public int ThanhToanPhiTreHen(int id_KH, int id_DVD, DateTime now)
        {
            PhieuThueTra phieu = context.phieuthuetras.Where(x => x.id_KhachHang == id_KH && x.id_DVD == id_DVD
                    && x.phiTreHan != 0).FirstOrDefault();
            phieu.phiTreHan = 0;
            phieu.ngayTraPhiTreHen = now;
            context.SaveChanges();
            return 1;
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
