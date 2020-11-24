using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class ePhieuThueTra
    {
        public int id_PhieuThue { get; set; }
        public DateTime ngayThue { get; set; }
        public DateTime? ngayTra { get; set; }
        public double? phiTreHan { get; set; }
        public virtual int id_KhachHang { get; set; }
        public virtual int id_DVD { get; set; }

    }
}
