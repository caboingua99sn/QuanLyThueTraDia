using DAL.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TieuDeRepository : IDisposable
    {
        private DataContext context = new DataContext();

        private bool disposedValue = false; // To detect redundant calls

        public List<TieuDe> getTieuDes()
        {
            var list = context.tieudes.ToList();
            return list;
        }

        public int Save(TieuDe p)
        {
            context.tieudes.Add(p);
            return context.SaveChanges();
        }

        public TieuDe Find(int id)
        {
            return context.tieudes.Where(p => p.id_TieuDe == id).FirstOrDefault();
        }
        public List<TieuDe> FindbyIDTheLoai(int id)
        {
            return context.tieudes.Where(p => p.id_TheLoai == id).ToList();
        }
        public int Delete(TieuDe p)
        {
            context.tieudes.Remove(p);
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
