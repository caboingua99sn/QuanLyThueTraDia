using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class eDVD
    {
        public int id_DVD { get; set; }
        public int trangThai { get; set; }
        public int id_TieuDe { get; set; }

        public override bool Equals(object obj)
        {
            return obj is eDVD dVD &&
                   id_TieuDe == dVD.id_TieuDe;
        }
    }
}
