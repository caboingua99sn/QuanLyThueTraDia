namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbQuanLyThueTraDia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        id_DVD = c.Int(nullable: false, identity: true),
                        trangThai = c.Int(nullable: false),
                        id_TieuDe = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_DVD)
                .ForeignKey("dbo.TieuDes", t => t.id_TieuDe, cascadeDelete: true)
                .Index(t => t.id_TieuDe);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        id_KhachHang = c.Int(nullable: false, identity: true),
                        tenKhachHang = c.String(),
                        soCMND = c.String(),
                        soDT = c.String(),
                    })
                .PrimaryKey(t => t.id_KhachHang);
            
            CreateTable(
                "dbo.PhieuDatTruocs",
                c => new
                    {
                        id_KhachHang = c.Int(nullable: false),
                        id_DVD = c.Int(),
                        id_PhieuDatTruoc = c.Int(nullable: false, identity: true),
                        ngayDatTruoc = c.DateTime(nullable: false),
                        tieude_id_TieuDe = c.Int(),
                    })
                .PrimaryKey(t => t.id_PhieuDatTruoc)
                .ForeignKey("dbo.DVDs", t => t.id_DVD)
                .ForeignKey("dbo.KhachHangs", t => t.id_KhachHang, cascadeDelete: true)
                .ForeignKey("dbo.TieuDes", t => t.tieude_id_TieuDe)
                .Index(t => t.id_KhachHang)
                .Index(t => t.id_DVD)
                .Index(t => t.tieude_id_TieuDe);
            
            CreateTable(
                "dbo.TieuDes",
                c => new
                    {
                        id_TieuDe = c.Int(nullable: false, identity: true),
                        tenTieuDe = c.String(),
                        id_TheLoai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_TieuDe)
                .ForeignKey("dbo.TheLoais", t => t.id_TheLoai, cascadeDelete: true)
                .Index(t => t.id_TheLoai);
            
            CreateTable(
                "dbo.PhieuThues",
                c => new
                    {
                        id_PhieuThue = c.Int(nullable: false, identity: true),
                        ngayThue = c.DateTime(nullable: false),
                        ngayTra = c.DateTime(nullable: false),
                        tinhTrang = c.Boolean(nullable: false),
                        phiTreHan = c.Double(nullable: false),
                        dvd_id_DVD = c.Int(),
                        khachhang_id_KhachHang = c.Int(),
                    })
                .PrimaryKey(t => t.id_PhieuThue)
                .ForeignKey("dbo.DVDs", t => t.dvd_id_DVD)
                .ForeignKey("dbo.KhachHangs", t => t.khachhang_id_KhachHang)
                .Index(t => t.dvd_id_DVD)
                .Index(t => t.khachhang_id_KhachHang);
            
            CreateTable(
                "dbo.TheLoais",
                c => new
                    {
                        id_TheLoai = c.Int(nullable: false, identity: true),
                        tenTheLoai = c.String(),
                        giaThue = c.Double(nullable: false),
                        thoiGianThue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_TheLoai);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TieuDes", "id_TheLoai", "dbo.TheLoais");
            DropForeignKey("dbo.PhieuThues", "khachhang_id_KhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.PhieuThues", "dvd_id_DVD", "dbo.DVDs");
            DropForeignKey("dbo.PhieuDatTruocs", "tieude_id_TieuDe", "dbo.TieuDes");
            DropForeignKey("dbo.DVDs", "id_TieuDe", "dbo.TieuDes");
            DropForeignKey("dbo.PhieuDatTruocs", "id_KhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.PhieuDatTruocs", "id_DVD", "dbo.DVDs");
            DropIndex("dbo.PhieuThues", new[] { "khachhang_id_KhachHang" });
            DropIndex("dbo.PhieuThues", new[] { "dvd_id_DVD" });
            DropIndex("dbo.TieuDes", new[] { "id_TheLoai" });
            DropIndex("dbo.PhieuDatTruocs", new[] { "tieude_id_TieuDe" });
            DropIndex("dbo.PhieuDatTruocs", new[] { "id_DVD" });
            DropIndex("dbo.PhieuDatTruocs", new[] { "id_KhachHang" });
            DropIndex("dbo.DVDs", new[] { "id_TieuDe" });
            DropTable("dbo.TheLoais");
            DropTable("dbo.PhieuThues");
            DropTable("dbo.TieuDes");
            DropTable("dbo.PhieuDatTruocs");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.DVDs");
        }
    }
}
