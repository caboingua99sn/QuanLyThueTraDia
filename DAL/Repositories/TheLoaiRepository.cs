using DAL.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TheLoaiRepository : IDisposable
    {
        private DataContext context = new DataContext();

        private bool disposedValue = false; // To detect redundant calls
        public List<TheLoai> getTheLoais()
        {
            var list = context.theloais.ToList();
            return list;
        }
        public TheLoai Find(int id)
        {
            return context.theloais.Where(p => p.id_TheLoai == id).FirstOrDefault();
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
