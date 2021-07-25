using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStieBanSach.Models;
using System.Data;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace WebStieBanSach.Controllers
{
    public class QuanLyChuDeController : Controller
    {

        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        // GET: QuanLyChuDe
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.ChuDes.ToList().OrderBy(n => n.MaChuDe).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(ChuDe MaChuDe)
        {
            db.ChuDes.Add(MaChuDe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChinhSua(int MaChuDe)
        {
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chude);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(ChuDe _ChuDe)
        {
            if (!ModelState.IsValid)
            {
                return View(_ChuDe);
            }
            
            

            db.Entry(_ChuDe).State =EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int MaChuDe)
        {
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chude);
        }

        [HttpPost, ActionName("Xoa")]
        [ValidateInput(false)]
        public ActionResult XacNhanXoa(int MaChuDe)
        {
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            List<Sach> lstSach = db.Saches.Where(n => n.MaChuDe == MaChuDe).ToList();
            if ((chude == null) || (lstSach.Count > 0))
            {
                if (chude == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                if (lstSach.Count > 0)
                {
                    return View(chude);
                }
            }
            db.ChuDes.Remove(chude);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}