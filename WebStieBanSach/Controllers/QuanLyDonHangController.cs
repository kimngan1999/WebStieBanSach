using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStieBanSach.Models;
using PagedList;
using PagedList.Mvc;
using System.Data;
using System.Data.Entity;

namespace WebStieBanSach.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        // GET: QuanLyDonHang
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.DonHangs.ToList().OrderBy(n => n.MaDonHang).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ChinhSua(int MaDonHang)
        {
            DonHang donhang = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(donhang);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(DonHang DonHang)
        {
            if (!ModelState.IsValid)
            {
                return View(DonHang);
            }
            db.Entry(DonHang).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}