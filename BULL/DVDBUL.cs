using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.CodeFirst;
using System.Data.Entity;
using Entity;


namespace BULL
{
    public class DVDBUL
    {
        DVDRepository dvddal;

        public DVDBUL()
        {
            dvddal = new DVDRepository();
        }

        public List<eDVD> getDVDs()
        {
            List<eDVD> list = new List<eDVD>();
            foreach (var item in dvddal.getDVDs())
            {
                eDVD tam = new eDVD();
                tam.id_DVD = item.id_DVD;
                tam.trangThai = item.trangThai;
                tam.id_TieuDe = item.id_TieuDe;
                list.Add(tam);
            }
            return list;
        }

        public List<eDVD> getDVDsByTrangThai(int trangthai)
        {
            List<eDVD> list = new List<eDVD>();
            foreach (var item in dvddal.getDVDsByTrangThai(trangthai))
            {
                eDVD tam = new eDVD();
                tam.id_DVD = item.id_DVD;
                tam.trangThai = item.trangThai;
                tam.id_TieuDe = item.id_TieuDe;
                list.Add(tam);
            }
            return list;
        }

        public List<eDVD> getDVDsByTieuDe(int tieude)
        {
            List<eDVD> list = new List<eDVD>();
            foreach (var item in dvddal.getDVDsByTieuDe(tieude))
            {
                eDVD tam = new eDVD();
                tam.id_DVD = item.id_DVD;
                tam.trangThai = item.trangThai;
                tam.id_TieuDe = item.id_TieuDe;
                list.Add(tam);
            }
            return list;
        }

        public void Save(eDVD d)
        {
            DVD item = new DVD();
            item.id_DVD = d.id_DVD;
            item.trangThai = d.trangThai;
            item.id_TieuDe = d.id_TieuDe;

            dvddal.Save(item);
        }

        public int DeleteDVD(int id)
        {
            dvddal.DeleteDVD(id);
            return 1;
        }

        public eDVD FindDVDById(int id)
        {
            DVD t = dvddal.Find(id);
            if (t != null)
            {
                eDVD e = new eDVD();

                e.id_DVD = t.id_DVD;
                e.trangThai = t.trangThai;
                e.id_TieuDe = t.id_TieuDe;

                return e;
            }
            return null;

        }

        public int UpdateTrangThaiDVD(int id, int trangthai)
        {
            return dvddal.UpdateTrangThaiDVD(id, trangthai);
        }

        public eDVD Updatee(int id)
        {
            DVD dv = dvddal.Find(id);
            if (dv != null)
            {
                dv = dvddal.Update(id);
                eDVD t = new eDVD();
                t.id_DVD = dv.id_DVD;
                t.trangThai = dv.trangThai;
                t.id_TieuDe = dv.id_TieuDe;

                return t;
            }
            return null;
        }
    }
}
