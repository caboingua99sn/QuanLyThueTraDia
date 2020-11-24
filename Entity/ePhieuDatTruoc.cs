using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ePhieuDatTruoc
    {
        public int id_PhieuDatTruoc { get; set; }
        public DateTime ngayDatTruoc { get; set; }
        public int id_KhachHang { get; set; }
        public int id_TieuDe { get; set; }
        public int? id_DVD { get; set; }
    }
}
