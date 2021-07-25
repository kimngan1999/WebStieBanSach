using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStieBanSach.Models;
using System.Data;
using System.Data.Entity;

namespace WebStieBanSach.Controllers
{
    public class NguoiDungController : Controller
    {
        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh)
        {
            if(ModelState.IsValid)
            {
                // chen du lieu vao bang khach hang
                db.KhachHangs.Add(kh); //luu vao model
                                       //Luu vao co so du lieu
                db.SaveChanges();
             
            }
            return View();

        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            String sTaiKhoan = f.Get("txtTaiKhoan").ToString();
            String sMatKhau = f.Get("txtMatKhau").ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if(kh!=null)
            {
                ViewBag.ThongBao = " Đăng nhập thành công!";
                    Session["TaiKhoan"] = kh;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = " Sai tên tài khoản hoặc mật khẩu!";
            return View();
        }

        public ActionResult HienThi(int _MaKH)
        {
            KhachHang khachhang = db.KhachHangs.SingleOrDefault(n => n.MaKH == _MaKH);
            if (khachhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachhang);
        }


        [HttpGet]
        public ActionResult ChinhSua(int _MaKH)
        {
            KhachHang khachhang = db.KhachHangs.SingleOrDefault(n => n.MaKH == _MaKH);
            if (khachhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachhang);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(KhachHang _KhachHang)
        {
            if (!ModelState.IsValid)
            {
                return View(_KhachHang);
            }
            db.Entry(_KhachHang).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult NguoiDungPartial()
        {
            if ((Session["TaiKhoan"] == null) || (Session["TaiKhoan"].ToString() == ""))
            {
                return PartialView();
            }
            ViewBag.KhachHang = (KhachHang)Session["TaiKhoan"];
            return PartialView();
        }

        public ActionResult DangXuat()
        {
            if ((Session["TaiKhoan"] == null) || (Session["TaiKhoan"].ToString() == ""))
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            Session["TaiKhoan"] = null;
            Session["GioHang"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NguoiDungQuanTri()
        {
            if ((Session["TaiKhoan"] == null) || (Session["TaiKhoan"].ToString() == ""))
            {
                return PartialView();
            }
            ViewBag.KhachHang = (KhachHang)Session["TaiKhoan"];
            return PartialView();
        }
    }
}