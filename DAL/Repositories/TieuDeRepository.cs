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

        public List<TieuDe> getListbyTenTieuDe(string ten)
        {
            return context.tieudes.Where(p => p.tenTieuDe.Equals(ten)).ToList();
        }

        public PhieuDatTruoc FindbyID(int id)
        {
            TieuDe c = context.tieudes.First(p => p.id_TieuDe == id);
            PhieuDatTruoc td = new PhieuDatTruoc();
            if (td.id_TieuDe == c.id_TieuDe)
            {
                return td;
            }
            return null;
        }

        public List<PhieuDatTruoc> FindPhieuDatTruocByidTieuDe(int id)
        {
            List<PhieuDatTruoc> lst = new List<PhieuDatTruoc>();
            List<PhieuDatTruoc> lstafter = new List<PhieuDatTruoc>();
            foreach (var item in lst)
            {
                if (item.id_TieuDe == id)
                {
                    lstafter.Add(item);
                }
            }
            return lstafter;
        }

        public TheLoai FindTheLoaiById(int id)
        {
            TheLoai tl = context.theloais.First(p => p.id_TheLoai == id);
            if (tl != null)
            {
                return tl; ;
            }
            return null;
        }

        //public int Delete(TieuDe p)
        //{
        //    context.tieudes.Remove(p);
        //    return context.SaveChanges();
        //}

        public int Delete(int idxoa)
        {
            var p = new TieuDe();
            p = context.tieudes.First(x => x.id_TieuDe.Equals(idxoa));
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
