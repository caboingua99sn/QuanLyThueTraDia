namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.DVDs", "id_TieuDe");
            AddForeignKey("dbo.DVDs", "id_TieuDe", "dbo.TieuDes", "id_TieuDe", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DVDs", "id_TieuDe", "dbo.TieuDes");
            DropIndex("dbo.DVDs", new[] { "id_TieuDe" });
        }
    }
}
