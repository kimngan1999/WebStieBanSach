using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStieBanSach.Models;

namespace WebStieBanSach.Controllers
{
    public class ChuDeController : Controller
    {
        // GET: ChuDe
        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        public ActionResult ChuDePartial()
        {
            return PartialView(db.ChuDes.Take(5).ToList());
        }

        /*Sach theo chu de*/
        public ViewResult SachTheoChuDe(int MaChuDe=0)
        {
            //Kiem tra chu de co ton tai hay k
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            ViewBag.lstChuDe = db.ChuDes.ToList();
            if (cd==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Truy xuat danh sach sach theo chu de
            List<Sach> lstsach = db.Saches.Where(n => n.MaChuDe == MaChuDe).OrderBy(n => n.GiaBan).ToList();
           if(lstsach.Count==0)
            {
                ViewBag.Sach = "Không có sách nào thuộc chủ đề này";
            }
            return View(lstsach);
        }
        //Hiển thị các chủ dề
        public ViewResult DanhMucCacChuDe ()
        {
            return View(db.ChuDes.ToList());
        }
    }
}