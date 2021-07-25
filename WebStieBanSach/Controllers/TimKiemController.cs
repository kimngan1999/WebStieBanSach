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
    public class TimKiemController : Controller
    {
        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        [HttpPost]
        // GET: TimKiem
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();

            //Phan trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
       
            if(lstKQTK.Count==0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.Saches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + "Kết quả!";
            return View(lstKQTK.OrderBy(n=>n.TenSach).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        // GET: TimKiem
        public ActionResult KetQuaTimKiem(string sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();

            //Phan trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;

            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.Saches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy  " + lstKQTK.Count + "  kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
        }
    }
}