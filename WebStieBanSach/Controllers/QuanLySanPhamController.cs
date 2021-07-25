using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStieBanSach.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Data.Entity;
using System.Data;
using PagedList;

namespace WebStieBanSach.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        // GET: QuanLySanPham
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.Saches.ToList().OrderBy(n => n.MaSach).ToPagedList(pageNumber, pageSize));
        }

        //Them moi
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //DUA DU LIEU VAO DROPDOWNLIST
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(Sach sach, HttpPostedFileBase fileUpload)
        {



            //DUA DU LIEU VAO DROPDOWNLIST
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            //Kiem tra duong dan anh bia
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }
            //them vao co so du lieu
            if (ModelState.IsValid)
            {
                //Luu ten cua file can them thu vien system.IO
                var fileName = Path.GetFileName(fileUpload.FileName);

                //luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), fileName);
                //Kiem ra hinh anh da ton tai chua
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                sach.AnhBia = fileUpload.FileName;
                db.Saches.Add(sach);
                db.SaveChanges();
            }
            return View();
        }
        //Chinh sua
        [HttpGet]
        public ActionResult ChinhSua(int MaSach)
        {
            // lay ra doi tuong sah theo ma
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // DUA DU LIEU VAO DROPDOWNLIST
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe", sach.MaChuDe);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);

            return View(sach);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(Sach sach, HttpPostedFileBase FileUpload)
        {
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe", sach.MaChuDe);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            //DUA DU LIEU VAO DROPDOWNLIST
            if (FileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View(sach);
            }
            //them vao co so du lieu
            if (ModelState.IsValid)
            {
                //Luu ten cua file can them thu vien system.IO
                var fileName = Path.GetFileName(FileUpload.FileName);

                //luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), fileName);
                //Kiem ra hinh anh da ton tai chua
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    FileUpload.SaveAs(path);
                }
                sach.AnhBia = FileUpload.FileName;
                db.Entry(sach).State = EntityState.Modified;
            db.SaveChanges();
        }
            return RedirectToAction("Index");
    }

        //Hien thi
    public ActionResult HienThi(int MaSach)
    {
        Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
        if (sach == null)
        {
            Response.StatusCode = 404;
            return null;
        }
        return View(sach);
    }

        //Xoa san pham
        [HttpGet]
        public ActionResult Xoa(int MaSach)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }

        [HttpPost, ActionName("Xoa")]
        [ValidateInput(false)]
        public ActionResult XacNhanXoa(int MaSach)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            //List<ChiTietDonHang> lstChiTietDonHang = db.ChiTietDonHangs.Where(n => n.MaSach == MaSach).ToList();
            if ((sach == null))
            {
                if (sach == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                //if (lstChiTietDonHang.Count > 0)
                //{
                //    return View(sach);
                //}
            }
            db.Saches.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}