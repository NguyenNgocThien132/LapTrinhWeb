using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001207118_NguyenNgocThien.Models;

namespace _2001207118_NguyenNgocThien.Controllers
{
    public class HomeController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        // GET: Home
        public ActionResult Index()
        {
            List<SanPham> SP = db.SanPhams.ToList();
            return View(SP);
        }

        public ActionResult Acer()
        {
            List<SanPham> SP = db.SanPhams.ToList();
            return View(SP);
        }

        public ActionResult ASUS()
        {
            List<SanPham> SP = db.SanPhams.ToList();
            return View(SP);
        }

        public ActionResult MSI()
        {
            List<SanPham> SP = db.SanPhams.ToList();
            return View(SP);
        }
        public ActionResult DELL()
        {
            List<SanPham> SP = db.SanPhams.ToList();
            return View(SP);
        }
        public ActionResult Apple()
        {
            List<SanPham> SP = db.SanPhams.ToList();
            return View(SP);
        }
    }
}