using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai2_TH10.Models; 
namespace Bai2_TH10.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        private Model1 data =  new Model1();
        // GET: TaiKhoan/DangNhap
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        // POST: TaiKhoan/DangNhap
        [HttpPost]
        public ActionResult DangNhap(string tendn, string matkhau)
        {
            // Tìm khách hàng có số điện thoại và mật khẩu trùng khớp
            var kh = data.tbl_KhachHang.FirstOrDefault(k => k.SoDT == tendn && k.MatKhau == matkhau);

            if (kh != null)
            {
                Session["TaiKhoan"] = kh;
                ViewBag.ThongBao = "Đăng nhập thành công!";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ThongBao = "Sai số điện thoại hoặc mật khẩu!";
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}