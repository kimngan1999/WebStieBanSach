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
    public class QuanLyNXBController : Controller
    {
        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        // GET: QuanLyNXB
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.NhaXuatBans.ToList().OrderBy(n => n.MaNXB).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(NhaXuatBan NhaXuatBan)
        {
            db.NhaXuatBans.Add(NhaXuatBan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChinhSua(int MaNXB)
        {
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nhaxuatban);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(NhaXuatBan NhaXuatBan)
        {
            if (!ModelState.IsValid)
            {
                return View(NhaXuatBan);
            }
            db.Entry(NhaXuatBan).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int MaNXB)
        {
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nhaxuatban);
        }

        [HttpPost, ActionName("Xoa")]
        [ValidateInput(false)]
        public ActionResult XacNhanXoa(int MaNXB)
        {
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            List<Sach> lstSach = db.Saches.Where(n => n.MaNXB == MaNXB).ToList();
            if ((nhaxuatban == null) || (lstSach.Count > 0))
            {
                if (nhaxuatban == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                if (lstSach.Count > 0)
                {
                    return View(nhaxuatban);
                }
            }
            db.NhaXuatBans.Remove(nhaxuatban);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult HienThi(int MaNXB)
        {
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nhaxuatban);
        }

      

    }
}