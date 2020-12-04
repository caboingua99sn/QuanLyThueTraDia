using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CodeFirst;

namespace DAL.Repositories
{
    public class KhachHangRepository : IDisposable
    {
        private DataContext context = new DataContext();

        private bool disposedValue = false; // To detect redundant calls

        public List<KhachHang> getKhachHangs()
        {
            return context.khachhangs.ToList();
        }
        
        public int Save(KhachHang p)
        {
            context.khachhangs.Add(p);
            return context.SaveChanges();
        }

        public int Delete(string idxoa)
        {
            var p = new KhachHang();
            p = context.khachhangs.First(x => x.id_KhachHang.Equals(idxoa));
            context.khachhangs.Remove(p);
            return context.SaveChanges();
        }

        public int Update(int idsua)
        {
            var p = new KhachHang();
            p = context.khachhangs.First(x => x.id_KhachHang==(idsua));
            return context.SaveChanges();
        }

        public KhachHang Find(int id)
        {
            return context.khachhangs.Where(p => p.id_KhachHang == id).FirstOrDefault();
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
