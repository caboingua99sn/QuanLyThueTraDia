﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class eKhachHang
    {
        public int id_KhachHang { get; set; }
        public string tenKhachHang { get; set; }
        public string soCMND { get; set; }
        public string soDT { get; set; }

        public override bool Equals(object obj)
        {
            return obj is eKhachHang hang &&
                   id_KhachHang == hang.id_KhachHang;
        }
    }
}
