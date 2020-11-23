using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CodeFirst
{
   public class TieuDe
    {
        [Key]
        public int id_TieuDe { get; set; }
        public string tenTieuDe { get; set; }
        //Khoa ngoai
        public virtual int id_TheLoai { get; set; }
        public virtual ICollection<PhieuDatTruoc> phieudattruocs { get; set; }
        public virtual ICollection<DVD> dvds { get; set; }
    }
}
