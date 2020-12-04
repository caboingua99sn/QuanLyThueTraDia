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
    public class TheLoaiBUL
    {
        TheLoaiRepository tldal;
        public TheLoaiBUL()
        {
            tldal = new TheLoaiRepository();
        }
        public List<eTheLoai> getTheLoais()
        {
            List<eTheLoai> list = new List<eTheLoai>();
            foreach (var item in tldal.getTheLoais())
            {
                eTheLoai tam = new eTheLoai();
                tam.id_TheLoai = item.id_TheLoai;
                tam.tenTheLoai = item.tenTheLoai;
                list.Add(tam);
            }
            return list;
        }

        public eTheLoai GetTheLoaiByID(int id)
        {
            eTheLoai tam = new eTheLoai();
            TheLoai item = tldal.Find(id);
            if (item != null)
            {
                tam.id_TheLoai = item.id_TheLoai;
                tam.tenTheLoai = item.tenTheLoai;
                tam.thoiGianThue = item.thoiGianThue;
                tam.giaThue = item.giaThue;
                return tam;
            }
            return null;
        }

        public void Save(eTheLoai d)
        {
            TheLoai item = new TheLoai();
            item.id_TheLoai = d.id_TheLoai;
            item.tenTheLoai = d.tenTheLoai;
            item.giaThue = d.giaThue;
            item.thoiGianThue = d.thoiGianThue;
            tldal.Save(item);
        }
        public int Delete(int idxoa)
        {
            tldal.Delete(idxoa);
            return 1;
        }

        public eTheLoai FindDVDById(int id)
        {
            TheLoai t = new TheLoai();
            t = tldal.Find(id);
            eTheLoai e = new eTheLoai();
            e.id_TheLoai = t.id_TheLoai;
            e.tenTheLoai = t.tenTheLoai;
            e.giaThue = t.giaThue;
            e.thoiGianThue = t.thoiGianThue;
            return e;

        }
    }
}
