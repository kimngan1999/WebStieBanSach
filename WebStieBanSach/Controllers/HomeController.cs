using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStieBanSach.Models;

using PagedList;
using PagedList.Mvc;
    
namespace WebStieBanSach.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        // GET: Home
        public ActionResult Index( int? page)
        {
            //Tao bien so san pham tren trang
            int pageSize = 9;
            //Tao bien so trang
            int pageNumber = (page ?? 1);
            return View(db.Saches.Where(n=>n.Moi==1).OrderBy(n=>n.GiaBan).ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Sach(int? page)
        {

            int pageSize = 9;
            //Tao bien so trang
            int pageNumber = (page ?? 1);
            return View(db.Saches.ToList().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GioiThieu()
        {

            return View();
        }

        public ActionResult LienHe()
        {
            ViewBag.Message = "Cảm ơn bạn đã quan tâm đến chúng tôi";
            return View();
        }
    }
}