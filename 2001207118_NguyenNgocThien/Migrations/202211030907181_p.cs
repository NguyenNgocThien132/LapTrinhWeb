namespace _2001207118_NguyenNgocThien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class p : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TheLoai",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoaiSP = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.SanPham", "IDTheLoai", c => c.Int(nullable: true));
            CreateIndex("dbo.SanPham", "IDTheLoai");
            AddForeignKey("dbo.SanPham", "IDTheLoai", "dbo.TheLoai", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "IDTheLoai", "dbo.TheLoai");
            DropIndex("dbo.SanPham", new[] { "IDTheLoai" });
            DropColumn("dbo.SanPham", "IDTheLoai");
            DropTable("dbo.TheLoai");
        }
    }
}
