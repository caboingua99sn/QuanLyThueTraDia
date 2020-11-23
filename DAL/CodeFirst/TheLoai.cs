using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CodeFirst
{
   public class TheLoai
    {
        [Key]
        public int id_TheLoai { get; set; }
        public string tenTheLoai { get; set; }
        public double giaThue { get; set; }
        public int thoiGianThue { get; set; }
        public virtual ICollection<TieuDe> tieudes { get; set; }

    }
}
