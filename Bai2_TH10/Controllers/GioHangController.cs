using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai2_TH10.Models;

namespace Bai2_TH10.Controllers
{
    public class GioHangController : Controller
    {
        private Model1 data = new Model1();

        // Lấy giỏ hàng hiện tại từ Session
        private GioHang LayGio()
        {
            GioHang gio = Session["GioHang"] as GioHang;
            if (gio == null)
            {
                gio = new GioHang();
                Session["GioHang"] = gio;
            }
            return gio;
        }

        // Thêm sản phẩm vào giỏ
        public ActionResult ThemGio(string maSP)
        {
            var sp = data.tbl_SanPham.FirstOrDefault(s => s.MaSP == maSP);
            if (sp != null)
            {
                GioHang gio = LayGio();
                gio.ThemVaoGio(sp);
            }
            return RedirectToAction("Index", "GioHang");
        }

        // Hiển thị giỏ hàng
        public ActionResult Index()
        {
            GioHang gio = LayGio();
            return View(gio);
        }
        public ActionResult XoaKhoiGio(string maSP)
        {
            GioHang gio = LayGio();
            gio.XoaKhoiGio(maSP);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CapNhat(string maSP, int soLuong)
        {
            GioHang gio = LayGio();
            gio.CapNhat(maSP, soLuong);
            return RedirectToAction("Index");
        }

        public ActionResult XoaGio()
        {
            GioHang gio = LayGio();
            gio.XoaGio();
            return RedirectToAction("Index");
        }
        // Hiển thị tổng số lượng trên header (dùng PartialView)
        public ActionResult GioHangPartial()
        {
            GioHang gio = Session["GioHang"] as GioHang;
            int sl = 0;
            if (gio != null)
            {
                sl = gio.TongSoLuong();
            }
            ViewBag.TongSoLuong = sl;
            return PartialView();
        }
    }

}