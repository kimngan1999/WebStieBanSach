using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStieBanSach.Models;

namespace WebStieBanSach.Controllers
{
    public class SachController : Controller
    {
        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        // GET: Sach moi partial
        public PartialViewResult SachMoiPartial()
        {
            var lstSachMoi = db.Saches.Take(3).ToList();
            return PartialView(lstSachMoi);
        }
        public ViewResult XemChiTiet(int MaSach=0)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if(sach ==null)
            {
                //Tra ve trang thai bao loi
                Response.StatusCode = 404;
                return null;

            }
            ViewBag.TenChuDe = db.ChuDes.Single(n => n.MaChuDe == sach.MaChuDe).TenChuDe;
            ViewBag.NhaXuatBan = db.NhaXuatBans.Single(x => x.MaNXB == sach.MaNXB).TenNXB; 
            return View(sach);
        }
    }
}