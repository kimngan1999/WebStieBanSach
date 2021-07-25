using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStieBanSach.Models;
using System.Web.Mvc;

namespace WebStieBanSach.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        #region Giỏ hàng
        //Lay gio hang
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //neu gio hang chua ton tai tien hanh tao list gio hang(session gio hang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
            //Them gio hang
            public ActionResult ThemGioHang(int iMaSach, string StrUrl)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            if(sach==null){
                Response.StatusCode = 404;
                return null;
            }
            //lay ra session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiem tra sach đã tòn tại hay chưa
            GioHang sanpham = lstGioHang.Find(n => n.iMaSach == iMaSach);
            if(sanpham == null)
            {
                sanpham = new GioHang(iMaSach);
                lstGioHang.Add(sanpham);
                return Redirect(StrUrl);

            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(StrUrl);
            }
        }
        //Cap nhat gio hang
        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            // Kiem tra masp sach

            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // lay gio hang tu session
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSach == iMaSP);
            if(sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        //Xoa gio hang
        public ActionResult XoaGioHang(int iMaSP)
        {
            // Kiem tra masp sach

            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // lay gio hang tu session
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSach == iMaSP);
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMaSach == iMaSP);
                return RedirectToAction("GioHang");
            }
            if(lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }

        //Xay Dung trang gio hang
        public ActionResult GioHang()
        {
            if (Session["GioHang"]== null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<GioHang> lstGioHang = LayGioHang();
            
            return View(lstGioHang);
        }
        //Xay dung tinh tong so luong va tong tien
        //Tinh tong so luong
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang !=null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
         
       //Tao partial gio hang
       public ActionResult GioHangPartial()
        {
            if(TongSoLuong()==0)
            {
                return PartialView();
            }

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }

        public ActionResult GioHangTongTien()
        {
            if (TongTien() <= 0)
            {
                return PartialView();
            }
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
       

        //Xay dung 1 view cho nguoi dung chinh sua gio hang
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<GioHang> lstGioHang = LayGioHang();

            return View(lstGioHang);
        }
        #endregion
        #region Đặt hàng
        //Xây dung chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng nhập
            if(Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            // Them don dat hang
            if(Session["GioHang"]==null)
            {
                RedirectToAction("Index", "Home");
            }
            //Them don hang
            DonHang dh = new DonHang();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();// lay session gio hang
            dh.MaKH = kh.MaKH;
            dh.NgayDat = DateTime.Now;
            dh.TinhTrangDonHang = 0;
            dh.NgayDat = DateTime.Now;
            dh.NgayGiao = DateTime.Now;
            //Them down hang vao co so du lieu
            db.DonHangs.Add(dh);
            db.SaveChanges();
            // Them chi tiet don hang
            foreach (var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDonHang = dh.MaDonHang;
                ctDH.MaSach = item.iMaSach;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = (decimal)item.dDonGia;
                db.ChiTietDonHangs.Add(ctDH);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("Index","Home");
        }
        public ActionResult HoaDon()
        {
            if ((Session["TaiKhoan"] == null) || (Session["TaiKhoan"].ToString() == ""))
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.KhachHang = (KhachHang)Session["TaiKhoan"];
            return View(lstGioHang);
        }



        #endregion
    }
}