namespace _2001207118_NguyenNgocThien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietSanPham",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDSanPham = c.Int(nullable: false),
                        CPU = c.String(),
                        ManHinh = c.String(),
                        RAM = c.String(),
                        DoHoa = c.String(),
                        LuuTru = c.String(),
                        HeDieuHanh = c.String(),
                        Pin = c.String(),
                        KhoiLuong = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SanPham", t => t.IDSanPham, cascadeDelete: true)
                .Index(t => t.IDSanPham);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ThuongHieuID = c.Int(nullable: false),
                        TenSP = c.String(),
                        SoLuong = c.Int(),
                        GiaTien = c.Double(),
                        GiaGiam = c.Double(),
                        NhaSanXuat = c.String(),
                        HinhAnh = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ThuongHieu", t => t.ThuongHieuID, cascadeDelete: true)
                .Index(t => t.ThuongHieuID);
            
            CreateTable(
                "dbo.ThuongHieu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NSX = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "ThuongHieuID", "dbo.ThuongHieu");
            DropForeignKey("dbo.ChiTietSanPham", "IDSanPham", "dbo.SanPham");
            DropIndex("dbo.SanPham", new[] { "ThuongHieuID" });
            DropIndex("dbo.ChiTietSanPham", new[] { "IDSanPham" });
            DropTable("dbo.ThuongHieu");
            DropTable("dbo.SanPham");
            DropTable("dbo.ChiTietSanPham");
        }
    }
}
