using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CodeFirst
{
   public class DVD
    {
        [Key]
        public int id_DVD { get; set; }
        public int trangThai { get; set; }

        //foreign key
        public int id_TieuDe { get; set; }
    }
}
