using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _2001207118_NguyenNgocThien.Models
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext() : base("MyconnectionString") { }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    }
}