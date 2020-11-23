using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CodeFirst
{
   public class PhieuThue
    {
        [Key]
        public int id_PhieuThue;
        public DateTime ngayThue;
        public DateTime ngayTra;
        public bool tinhTrang;
        public double phiTreHan;

        //foreign key
        [Column(Order = 1)]
        public int id_KhachHang;
        public virtual KhachHang khachhang { get; set; }

        [Column(Order = 2)]
        public int id_DVD;
        public virtual DVD dvd { get; set; }

    }
}
