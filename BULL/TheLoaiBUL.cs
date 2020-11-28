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
        TheLoaiRepository tddal;
        public TheLoaiBUL()
        {
            tddal = new TheLoaiRepository();
        }
        public List<eTheLoai> getTheLoais()
        {
            List<eTheLoai> list = new List<eTheLoai>();
            foreach (var item in tddal.getTheLoais())
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
            TheLoai item = tddal.Find(id);
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
    }
}
