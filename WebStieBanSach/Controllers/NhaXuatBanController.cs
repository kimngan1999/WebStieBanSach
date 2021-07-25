using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStieBanSach.Models;

namespace WebStieBanSach.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: NhaXuatBan
        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        public ActionResult NhaXuatBanPartial()
        {
            return PartialView(db.NhaXuatBans.Take(10).OrderBy(x => x.TenNXB).ToList());
        }

        //Hien thi sach theo nha xuat ban
        public ViewResult SachTheoNXB(int MaNXB)
        {
            NhaXuatBan nxb = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Truy xuat danh sach sach theo nha xuat ban
            List<Sach> lstsach = db.Saches.Where(n => n.MaNXB == MaNXB).OrderBy(n => n.GiaBan).ToList();
            if (lstsach.Count == 0)
            {
                ViewBag.Sach = "Không có sách nào thuộc nha xuat ban này";
            }
            return View(lstsach);
        }
            //Hien thi sach theo nha xuat ban
            public ViewResult DanhMucNXB()
        {
            return View(db.NhaXuatBans.ToList());
        }
    }
    
}