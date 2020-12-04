using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CodeFirst;

namespace DAL.Repositories
{
    public class DVDRepository : IDisposable
    {
        private DataContext context = new DataContext();

        private bool disposedValue = false;


        public List<DVD> getDVDs()
        {
            return context.dvds.ToList();
        }

        public List<DVD> getDVDsByTrangThai(int trangthai)
        {
            return context.dvds.Where(x => x.trangThai == trangthai).ToList();
        }

        public List<DVD> getDVDsByTieuDe(int tieude)
        {
            return context.dvds.Where(x => x.id_TieuDe == tieude).ToList();
        }

        public int Save(DVD d)
        {
            context.dvds.Add(d);
            return context.SaveChanges();
        }

        public int DeleteDVD(int idxoa)
        {
            var d = new DVD();
            d = context.dvds.First(x => x.id_DVD == idxoa);
            context.dvds.Remove(context.dvds.First(x => x.id_DVD == idxoa));
            return context.SaveChanges();

        }

        public DVD Find(int id)
        {
            DVD dvd = context.dvds.FirstOrDefault(p => p.id_DVD == id);
            if (dvd != null)
            {
                return dvd;
            }
            return null;

        }

        public int UpdateTrangThaiDVD(int id, int trangthai)
        {
            DVD d = context.dvds.Where(x => x.id_DVD == id).FirstOrDefault();
            if (d != null)
            {
                d.trangThai = trangthai;
                return context.SaveChanges();
            }
            return -1;
        }

        public DVD Update(int id)
        {
            DVD d = context.dvds.FirstOrDefault(predicate => predicate.id_DVD == id);
            if (d != null)
            {
                DVD t = new DVD();
                t.id_DVD = d.id_DVD;
                t.trangThai = d.trangThai;
                t.id_TieuDe = d.id_TieuDe;
                context.SaveChanges();
                return t;
            }
            else
                return null;
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
