using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai01.Models;
namespace Bai01.Controllers
{
    public class TaiKhoanController : Controller
    {
        private Model1 data = new Model1();
        // GET: TaiKhoan
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                // kiểm tra trùng tên đăng nhập
                var check = data.KHACHHANGs.FirstOrDefault(k => k.TAIKHOAN == kh.TAIKHOAN);
                if (check != null)
                {
                    ViewBag.ThongBao = "Tên đăng nhập đã tồn tại!";
                    return View();
                }

                kh.MAKH = "KH" + (data.KHACHHANGs.Count() + 1).ToString("00");
                data.KHACHHANGs.Add(kh);
                data.SaveChanges();
                ViewBag.ThongBao = "Đăng ký thành công!";
                return RedirectToAction("DangNhap");
            }

            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string tendn, string matkhau)
        {
            var kh = data.KHACHHANGs.FirstOrDefault(k => k.TAIKHOAN == tendn && k.MATKHAU == matkhau);
            if (kh != null)
            {
                Session["TaiKhoan"] = kh;
                ViewBag.ThongBao = "Đăng nhập thành công!";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ThongBao = "Sai tên đăng nhập hoặc mật khẩu!";
            return View();
        }

        // --- Đăng xuất ---
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}