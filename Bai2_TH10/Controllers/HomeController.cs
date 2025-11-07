using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai2_TH10.Models;
namespace Bai2_TH10.Controllers
{
    public class HomeController : Controller
    {
        private Model1 data = new Model1();
        public ActionResult Index()
        {
           var listSanPham=data.tbl_SanPham.ToList();
            return View(listSanPham);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult ChiTietSP(string id)
        {

            if (string.IsNullOrEmpty(id))
                return HttpNotFound();

            // Tìm sản phẩm theo mã
            var sp = data.tbl_SanPham
                         .FirstOrDefault(s => s.MaSP == id);

            if (sp == null)
                return HttpNotFound();

            return View(sp);
        }
    }
}