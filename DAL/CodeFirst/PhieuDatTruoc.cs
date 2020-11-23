using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CodeFirst
{
    public class PhieuDatTruoc
    {
        [Key]
        public int id_PhieuDatTruoc { get; set; }
        public DateTime ngayDatTruoc { get; set; }

        //foreign key
       
        [Column(Order = 1)]
        public int id_KhachHang { get; set; }
        public virtual KhachHang khachhang { get; set; }

       
        [Column(Order = 2)]
        public int id_TieuDe;
        public virtual TieuDe tieude { get; set; }

       
        [Column(Order = 3)]
        public int? id_DVD { get; set; }
        public virtual DVD dvd { get; set; }
    }
}
