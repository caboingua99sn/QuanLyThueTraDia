using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CodeFirst;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class PhieuDatTruocRepository : IDisposable
    {
        private DataContext context = new DataContext();

        private bool disposedValue = false;


        public List<PhieuDatTruoc> getPhieuDatTruocs()
        {
            return context.phieudattruocs.ToList();
        }

        public TieuDe FindTieuDeById(int id)
        {
            PhieuDatTruoc c = context.phieudattruocs.First(p => p.id_TieuDe == id);
            TieuDe td = new TieuDe();
            if (td.id_TieuDe == c.id_TieuDe)
            {
                return td;
            }
            return null;

        }

        public int Save(PhieuDatTruoc p)
        {
            context.phieudattruocs.Add(p);
            return context.SaveChanges();
        }

        public int Update(int id_phieu, int id_dvd)
        {
            PhieuDatTruoc phieu = context.phieudattruocs.Where(x => x.id_PhieuDatTruoc == id_phieu).FirstOrDefault();
            phieu.id_DVD = id_dvd;
            return context.SaveChanges();
        }

        public PhieuDatTruoc GetPhieuDatTruocByID(int id)
        {
            return context.phieudattruocs.Where(x => x.id_DVD == id && x.trangThai == 0).FirstOrDefault();
        }

        public List<PhieuDatTruoc> GetPhieuDatTruocsByDvdNull()
        {
            return context.phieudattruocs.Where(x => x.id_DVD == null).ToList();
        }

        public List<KhachHang> FindKhachHangById(int id)
        {

            List<KhachHang> lst = new List<KhachHang>();
            List<KhachHang> lstafter = new List<KhachHang>();
            foreach (var item in lst)
            {
                if (item.id_KhachHang == id)
                    lstafter.Add(item);

            }
            return lstafter;

        }

        public KhachHang FindKHBYID(int id)
        {
            PhieuDatTruoc c = context.phieudattruocs.First(p => p.id_KhachHang == id);
            KhachHang td = new KhachHang();
            if (td.id_KhachHang == c.id_KhachHang)
            {
                return td;
            }
            return null;
        }

        public int DeletePDTByIDPhieu_IDTieuDe(int idphieu)
        {
            PhieuDatTruoc pdt = context.phieudattruocs.Where(x => x.id_PhieuDatTruoc == idphieu).FirstOrDefault();
            context.phieudattruocs.Remove(pdt);
            return context.SaveChanges();
        }

        public int DeletePDTByIDKH(int id)
        {
            PhieuDatTruoc pdt = context.phieudattruocs.FirstOrDefault(x => x.id_KhachHang == id);
            context.phieudattruocs.Remove(pdt);
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
