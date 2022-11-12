using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001207118_NguyenNgocThien.Models;

namespace _2001207118_NguyenNgocThien.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        ShopDBContext db = new ShopDBContext();
        public ActionResult Index(int Page = 1)
        {

            List<SanPham> laptop = db.SanPhams.ToList();

            //Phân Trang
            int NoOfRecordPerPage = 12;
            int NoOfPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(laptop.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (Page - 1) * NoOfRecordPerPage;
            laptop = laptop.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            ViewBag.Page = Page;
            ViewBag.NoOfPage = NoOfPage;
            ViewBag.NoOfRecordPerPage = NoOfRecordPerPage;

            return View(laptop);
        }
        public ActionResult SapXepTangGiam(int Page = 1, string sapxep = "")
        {
            List<SanPham> laptop = db.SanPhams.ToList();
            //Sắp xếp tăng - giảm
            switch (sapxep)
            {
                case "tang":
                    laptop = laptop.OrderBy(r => r.GiaTien).ToList();
                    break;
                case "giam":
                    laptop = laptop.OrderByDescending(r => r.GiaTien).ToList();
                    break;
                default:
                    break;
            }
            ViewBag.sapxep = sapxep;

            //Phân Trang
            int NoOfRecordPerPage = 12;
            int NoOfPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(laptop.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (Page - 1) * NoOfRecordPerPage;
            laptop = laptop.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            ViewBag.Page = Page;
            ViewBag.NoOfPage = NoOfPage;
            ViewBag.NoOfRecordPerPage = NoOfRecordPerPage;
            return View(laptop);
        }

        public ActionResult SapXepTheoGia(string sort = "")
        {
            List<SanPham> laptop = db.SanPhams.ToList();

            switch (sort)
            {
                case "value1":
                    //Dưới 10 triệu
                    laptop = laptop.Where(row => row.GiaTien < 10000000).ToList();
                    break;
                case "value2":
                    //10 - 15 triệu
                    laptop = laptop.Where(row => row.GiaTien > 10000000 && row.GiaTien < 15000000).ToList();
                    break;
                case "value3":
                    //15 - 20 triệu
                    laptop = laptop.Where(row => row.GiaTien > 15000000 && row.GiaTien < 20000000).ToList();
                    break;
                case "value4":
                    //20 - 25 triệu
                    laptop = laptop.Where(row => row.GiaTien > 20000000 && row.GiaTien < 25000000).ToList();
                    break;
                case "value5":
                    //25 - 30 triệu
                    laptop = laptop.Where(row => row.GiaTien > 25000000 && row.GiaTien < 30000000).ToList();
                    break;
                case "value6":
                    //Trên 30 triệu
                    laptop = laptop.Where(row => row.GiaTien > 30000000).ToList();
                    break;
                default:
                    break;
            }
            return View(laptop);
        }

        public ActionResult SapXepTheoThuongHieu(string thuonghieu = "")
        {
            List<SanPham> laptop = db.SanPhams.ToList();
            //Thương hiệu
            switch (thuonghieu)
            {
                case "Acer":
                    laptop = laptop.Where(r => r.NhaSanXuat == "Acer").ToList();
                    break;
                case "ASUS":
                    laptop = laptop.Where(r => r.NhaSanXuat == "ASUS").ToList();
                    break;
                case "MSI":
                    laptop = laptop.Where(r => r.NhaSanXuat == "MSI").ToList();
                    break;
                case "DELL":
                    laptop = laptop.Where(r => r.NhaSanXuat == "DELL").ToList();
                    break;
                case "Apple":
                    laptop = laptop.Where(r => r.NhaSanXuat == "Apple").ToList();
                    break;
                default:
                    break;
            }
            return View(laptop);
        }
        public ActionResult SapXepPhanLoai(string phanloai = "")
        {
            List<SanPham> laptop = db.SanPhams.ToList();

            switch (phanloai)
            {
                case "Gaming":
                    laptop = laptop.Where(r => r.IDTheLoai == 1).ToList();
                    break;
                case "HocSinh":
                    laptop = laptop.Where(r => r.IDTheLoai == 2).ToList();
                    break;
                case "VanPhong":
                    laptop = laptop.Where(r => r.IDTheLoai == 3).ToList();
                    break;
                case "DoanhNhan":
                    laptop = laptop.Where(r => r.IDTheLoai == 4).ToList();
                    break;
                case "DoHoa":
                    laptop = laptop.Where(r => r.IDTheLoai == 5).ToList();
                    break;
                default:
                    break;
            }
            return View(laptop);
        }
        public ActionResult SeriesSanPham(string series="")
        {
            List<SanPham> laptop = db.SanPhams.Where(r => r.TenSP.Contains(series)).ToList();
            return View(laptop);
        }
        public ActionResult ChiTietSanPham(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(row => row.ID == id).FirstOrDefault();
            ViewBag.sp = db.SanPhams.ToList();
            return View(ctsp);
        }
    }
}