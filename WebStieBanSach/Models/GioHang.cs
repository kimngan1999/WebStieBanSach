using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebStieBanSach.Models
{
    public class GioHang
    {

        QuanLyBanSachMVC5Entities db = new QuanLyBanSachMVC5Entities();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien {
            get { return iSoLuong * dDonGia; }
                }
        //Hàm tạo giỏ hàng
        public GioHang(int MaSach)
        {
            iMaSach = MaSach;
            Sach sach = db.Saches.Single(n => n.MaSach == iMaSach);
            sTenSach = sach.TenSach;
            sAnhBia = sach.AnhBia;
            dDonGia =double.Parse(sach.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}