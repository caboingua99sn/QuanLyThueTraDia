using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CodeFirst
{
   public class PhieuThueTra
    {
        [Key]
        public int id_PhieuThue { get; set; }
        public DateTime ngayThue { get; set; }
        public DateTime? ngayTra { get; set; }
        public DateTime? ngayTraPhiTreHen { get; set; }
        public double? phiTreHan { get; set; }

        //foreign key

        [Column(Order = 1)]
        public virtual int id_KhachHang { get; set; }


        [Column(Order = 2)]
        public virtual int id_DVD { get; set; }

    }
}
