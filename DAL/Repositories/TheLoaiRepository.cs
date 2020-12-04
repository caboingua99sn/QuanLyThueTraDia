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

        public void Save(TheLoai t)
        {
            context.theloais.Add(t);
            context.SaveChanges();
        }

        public TheLoai Find(int id)
        {
            var theloai = context.theloais.Where(p => p.id_TheLoai == id).FirstOrDefault();
            return theloai;
        }

        public int Delete(int idxoa)
        {
            var d = new TheLoai();
            d = context.theloais.First(x => x.id_TheLoai == idxoa);
            context.theloais.Remove(d);
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
