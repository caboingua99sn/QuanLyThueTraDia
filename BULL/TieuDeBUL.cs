using DAL.CodeFirst;
using DAL.Repositories;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULL
{
    public class TieuDeBUL
    {
        TieuDeRepository tddal;
        public TieuDeBUL()
        {
            tddal = new TieuDeRepository();
        }
        public List<eTieuDe> getTieuDes()
        {
            List<eTieuDe> list = new List<eTieuDe>();
            foreach (var item in tddal.getTieuDes())
            {
                eTieuDe tam = new eTieuDe();
                tam.id_TieuDe = item.id_TieuDe;
                tam.tenTieuDe = item.tenTieuDe;
                tam.id_TheLoai = item.id_TheLoai;
                list.Add(tam);
            }
            return list;
        }

        public int Save(eTieuDe item)
        {
            TieuDe tam = new TieuDe();
            tam.tenTieuDe = item.tenTieuDe;
            tam.id_TheLoai = item.id_TheLoai;
            tddal.Save(tam);
            return 1;
        }
        public int Delete(int id)
        {
            TieuDe item = tddal.Find(id);
            if (item != null)
            {
                tddal.Delete(item);
                return 1;
            }
            return 0;
        }
        public eTieuDe GetTieuDeByID(int id)
        {
            eTieuDe tam = new eTieuDe();
            TieuDe item = tddal.Find(id);
            if (item != null)
            {
                tam.id_TieuDe = item.id_TieuDe;
                tam.tenTieuDe = item.tenTieuDe;
                tam.id_TheLoai = item.id_TheLoai;
                return tam;
            }
            return null;
        }
        public List<eTieuDe> GetTieuDeByIDTL(int id)
        {
            List<eTieuDe> ls = new List<eTieuDe>();
            List<TieuDe> item = tddal.FindbyIDTheLoai(id);
            if (item != null)
            {
                foreach (var i in item)
                {
                    eTieuDe tam = new eTieuDe();
                    tam.id_TieuDe = i.id_TieuDe;
                    tam.tenTieuDe = i.tenTieuDe;
                    tam.id_TheLoai = i.id_TheLoai;
                    ls.Add(tam);
                }
                return  ls;
            }
            return null;
        }
    }
}
