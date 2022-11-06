using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001207118_NguyenNgocThien.Models;
using System.IO;

namespace _2001207118_NguyenNgocThien.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ShopDBContext db = new ShopDBContext();
        public ActionResult QuanLy(string search = "", string SortColumn = "ID", string IconClass = "fa-sort-asc", int Page = 1)
        {
            //List<SanPham> sp = db.SanPhams.ToList();

            //search
            List<SanPham> sp = db.SanPhams.Where(row => row.TenSP.Contains(search)).ToList();
            ViewBag.Search = search;
            //sort  
            ViewBag.SortColum = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "ID")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.ID).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.ID).ToList();
                }
            }
            else if (SortColumn == "TenSP")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.TenSP).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.TenSP).ToList();
                }
            }
            else if (SortColumn == "GiaTien")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.GiaTien).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.GiaTien).ToList();
                }
            }

            //Paging
            int NoOfRecordPerPage = 20;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (Page - 1) * NoOfRecordPerPage;
            ViewBag.Page = Page;
            ViewBag.NoOfPages = NoOfPages;

            sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(sp);
        }
        public ActionResult ChiTietSP(int id)
        {
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(row => row.ID == id).FirstOrDefault();
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            ViewBag.sp = db.SanPhams.ToList();
            return View(ctsp);
        }
        public ActionResult Insert()
        {
            List<ThuongHieu> th = db.ThuongHieus.ToList();
            ViewBag.th = th;
            return View();
        }
        [HttpPost]
        public ActionResult Insert(SanPham sanpham, HttpPostedFileBase HinhAnh)
        {
            List<ThuongHieu> th = db.ThuongHieus.ToList();
            ViewBag.th = th;
            string FileName = Path.GetFileName(HinhAnh.FileName);
            if (sanpham.NhaSanXuat == "Acer")
            {
                string path = Path.Combine(Server.MapPath("~/img/Acer"), FileName);
                HinhAnh.SaveAs(path);
            }
            if (sanpham.NhaSanXuat == "ASUS")
            {
                string path = Path.Combine(Server.MapPath("~/img/ASUS"), FileName);
                HinhAnh.SaveAs(path);
            }
            if (sanpham.NhaSanXuat == "DELL")
            {
                string path = Path.Combine(Server.MapPath("~/img/DELL"), FileName);
                HinhAnh.SaveAs(path);
            }
            if (sanpham.NhaSanXuat == "MSI")
            {
                string path = Path.Combine(Server.MapPath("~/img/MSI"), FileName);
                HinhAnh.SaveAs(path);
            }
            if (sanpham.NhaSanXuat == "Apple")
            {
                string path = Path.Combine(Server.MapPath("~/img/Apple"), FileName);
                HinhAnh.SaveAs(path);
            }
            sanpham.HinhAnh = FileName;
            db.SanPhams.Add(sanpham);
            db.SaveChanges();
            return RedirectToAction("quanly");
        }
        public ActionResult DeleteSanPham(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(row => row.IDSanPham == id).FirstOrDefault();
            return View(sp);
        }
        [HttpPost]
        public ActionResult DeleteSanPham(int id, SanPham p)
        {
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(row => row.IDSanPham == id).FirstOrDefault();
            if(ctsp !=null)
            {
                db.ChiTietSanPhams.Remove(ctsp);
                db.SaveChanges();
            }    
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("quanly");
        }
        public ActionResult Edit(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            List<ThuongHieu> th = db.ThuongHieus.ToList();
            ViewBag.th = th;
            return View(sp);
        }
        [HttpPost]
        public ActionResult Edit(int id, SanPham sanpham, HttpPostedFileBase HinhAnh)
        {
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            List<ThuongHieu> th = db.ThuongHieus.ToList();
            ViewBag.th = th;
            //update SanPham
            sp.TenSP = sanpham.TenSP;
            sp.SoLuong = sanpham.SoLuong;
            sp.GiaTien = sanpham.GiaTien;
            sp.GiaGiam = sanpham.GiaGiam;
            sp.NhaSanXuat = sanpham.NhaSanXuat;
            //sp.HinhAnh = sanpham.HinhAnh;
            if(HinhAnh !=null && HinhAnh.ContentLength > 0)
            {

                string FileName = Path.GetFileName(HinhAnh.FileName);
                if(sp.NhaSanXuat =="Acer")
                {
                    string path = Path.Combine(Server.MapPath("~/img/Acer"), FileName);
                    HinhAnh.SaveAs(path);
                }
                if (sp.NhaSanXuat == "ASUS")
                {
                    string path = Path.Combine(Server.MapPath("~/img/ASUS"), FileName);
                    HinhAnh.SaveAs(path);
                }
                if (sp.NhaSanXuat == "DELL")
                {
                    string path = Path.Combine(Server.MapPath("~/img/DELL"), FileName);
                    HinhAnh.SaveAs(path);
                }
                if (sp.NhaSanXuat == "MSI")
                {
                    string path = Path.Combine(Server.MapPath("~/img/MSI"), FileName);
                    HinhAnh.SaveAs(path);
                }
                if (sp.NhaSanXuat == "Apple")
                {
                    string path = Path.Combine(Server.MapPath("~/img/Apple"), FileName);
                    HinhAnh.SaveAs(path);
                }
                sp.HinhAnh = FileName;
                db.SaveChanges();
            }
            else
            {
                sp.HinhAnh = sanpham.HinhAnh;
            }    
            db.SaveChanges();
            return RedirectToAction("quanly");
        }
        public ActionResult EditSanPham(int id)
        {
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(row => row.IDSanPham == id).FirstOrDefault();
            return View(ctsp);
        }
        [HttpPost]
        public ActionResult EditSanPham(int id, ChiTietSanPham chitietsp)
        {
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(row => row.IDSanPham == id).FirstOrDefault();
            //SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            //update ChiTietSanPham
            ctsp.CPU = chitietsp.CPU;
            ctsp.ManHinh = chitietsp.ManHinh;
            ctsp.RAM = chitietsp.RAM;
            ctsp.DoHoa = chitietsp.DoHoa;
            ctsp.LuuTru = chitietsp.LuuTru;
            ctsp.HeDieuHanh = chitietsp.HeDieuHanh;
            ctsp.Pin = chitietsp.Pin;
            ctsp.KhoiLuong = chitietsp.KhoiLuong;

            db.SaveChanges();
            return RedirectToAction("quanly");
        }
    }
}