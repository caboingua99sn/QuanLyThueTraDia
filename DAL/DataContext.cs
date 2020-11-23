using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.CodeFirst;

namespace DAL
{
    public class DataContext: DbContext
    {
        public DataContext() : base("QuanLyThueTraDia")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<KhachHang> khachhangs { get; set; }
        public DbSet<DVD> dvds { get; set; }
        public DbSet<PhieuDatTruoc> phieudattruocs { get; set; }
        public DbSet<PhieuThueTra> phieuthuetras { get; set; }
        public DbSet<TheLoai> theloais { get; set; }
        public DbSet<TieuDe> tieudes { get; set; }


    }

    
}
