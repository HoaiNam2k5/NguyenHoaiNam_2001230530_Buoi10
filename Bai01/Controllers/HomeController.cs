using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai01.Models;

namespace Bai01.Controllers
{
    public class HomeController : Controller
    {

        private Model1 data = new Model1();
        public ActionResult DSMenu_Chude(){

            Model1 data = new Model1();
            List<CHUDE> dsCD=data.CHUDEs.Take(10).ToList();
            return PartialView(dsCD);
                }
        public ActionResult DSMenu_NXB()
        {

            Model1 data = new Model1();
            List<NHAXUATBAN> dsxb = data.NHAXUATBANs.Take(10).ToList();
            return PartialView(dsxb);
        }
        // Hiển thị sách theo chủ đề khi người dùng click
        public ActionResult HTSachTheoChuDe(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var chuDe = data.CHUDEs.FirstOrDefault(c => c.MACHUDE == id);
            if (chuDe == null)
            {
                return HttpNotFound();
            }

            var dsSach = data.SACHes.Where(s => s.MACHUDE == id).ToList();
            ViewBag.tenchude = chuDe.TENCHUDE;

            return View(dsSach);
        }
        public ActionResult HTSachTheoNXB(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var nxb = data.NHAXUATBANs.FirstOrDefault(n => n.MANXB == id);
            if (nxb == null)
            {
                return HttpNotFound();
            }

            var dsSach = data.SACHes.Where(s => s.MANXB == id).ToList();
            ViewBag.tennxb = nxb.TENNXB;

            return View(dsSach);
        }
        //tìm kiếm nâng cao
        public ActionResult TimKiem(string keyword, string machude, decimal? minPrice, decimal? maxPrice)
        {
            var ds = data.SACHes.AsQueryable();

            // Lọc theo từ khóa
            if (!string.IsNullOrEmpty(keyword))
            {
                ds = ds.Where(s => s.TENSACH.Contains(keyword) || s.MOTA.Contains(keyword));
            }

            // Lọc theo chủ đề
            if (!string.IsNullOrEmpty(machude))
            {
                ds = ds.Where(s => s.MACHUDE == machude);
            }

            // Lọc theo giá
            if (minPrice.HasValue)
            {
                ds = ds.Where(s => s.GIABAN >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                ds = ds.Where(s => s.GIABAN <= maxPrice.Value);
            }

            ViewBag.keyword = keyword;
            ViewBag.machude = machude;
            ViewBag.minPrice = minPrice;
            ViewBag.maxPrice = maxPrice;
            ViewBag.Title = "Kết quả tìm kiếm";

            return View(ds.ToList());
        }

        public ActionResult Index()
        {
            Model1 data = new Model1();
            List<SACH> dsSAch =data.SACHes.OrderByDescending(s=>s.NGAYCAPNHAP).Take(5).ToList();   
            return View(dsSAch);
        }
        [HttpGet]
        public ActionResult ChiTietSach(string id)
        {
            Model1 data = new Model1();
            if (string.IsNullOrEmpty(id))
                return HttpNotFound();

            // Tìm sách theo mã
            var sach = data.SACHes
                .Include("CHUDE")
                .Include("NHAXUATBAN")
                .FirstOrDefault(s => s.MASACH == id);

            if (sach == null)
                return HttpNotFound();

            return View(sach);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}