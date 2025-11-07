using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai2_TH10.Models;
namespace Bai2_TH10.Controllers
{
    public class AdminController : Controller
    {
        private Model1 data = new Model1();
        public ActionResult Index()
        {
            var listSanPham = data.tbl_SanPham.ToList();
            return View(listSanPham);
        }

        // Thêm sản phẩm
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }

        // Thêm sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi(tbl_SanPham sp)
        {
            if (ModelState.IsValid)
            {
                data.tbl_SanPham.Add(sp);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sp);
        }

        //  Sửa sản phẩm
        [HttpGet]
        public ActionResult Sua(string id)
        {
            if (string.IsNullOrEmpty(id)) return HttpNotFound();
            var sp = data.tbl_SanPham.FirstOrDefault(s => s.MaSP == id);
            if (sp == null) return HttpNotFound();
            return View(sp);
        }

        //  Sửa sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sua(tbl_SanPham sp)
        {
            if (ModelState.IsValid)
            {
                var existing = data.tbl_SanPham.FirstOrDefault(s => s.MaSP == sp.MaSP);
                if (existing != null)
                {
                    existing.TenSP = sp.TenSP;
                    existing.DonGia = sp.DonGia;
                    existing.HinhAnh = sp.HinhAnh;
                    existing.MoTa = sp.MoTa;
                    existing.SoLuongTon = sp.SoLuongTon;
                    data.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(sp);
        }

        // Xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(string id)
        {
            if (string.IsNullOrEmpty(id)) return HttpNotFound();
            var sp = data.tbl_SanPham.FirstOrDefault(s => s.MaSP == id);
            if (sp == null) return HttpNotFound();
            return View(sp);
        }

        //Xóa sản phẩm
        [HttpPost, ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoa(string id)
        {
            var sp = data.tbl_SanPham.FirstOrDefault(s => s.MaSP == id);
            if (sp != null)
            {
                data.tbl_SanPham.Remove(sp);
                data.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}