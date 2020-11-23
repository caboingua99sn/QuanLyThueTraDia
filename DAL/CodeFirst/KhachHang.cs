using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CodeFirst
{
   public class KhachHang
    {
        [Key]
        public int id_KhachHang { get; set; }
        public string tenKhachHang { get; set; }
        public string soCMND { get; set; }
        public string soDT { get; set; }
        public virtual ICollection<PhieuDatTruoc> phieudattruocs { get; set; }
        public virtual ICollection<PhieuThueTra> phieuthues { get; set; }
    }
}
