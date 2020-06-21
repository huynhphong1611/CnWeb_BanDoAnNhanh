using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website_BuyFood.ViewModel;

namespace Website_BuyFood.Models
{
    public class KhachHangDao
    {
        MyDBContext db = null;
        public KhachHangDao()
        {
            db = new MyDBContext();
        }
        public int getMaKH(string TenDangNhap)
        {
            int kq = db.Database.SqlQuery<int>("select MaKH from KhachHang where TenDangNhap = @tendangnhap",
                        new SqlParameter("@tendangnhap", TenDangNhap)).FirstOrDefault();
            return kq;
        }
        public KhachHang LayThongTinKhachHang(int MaKH)
        {
            KhachHang kq = db.KhachHangs.SqlQuery("select * from KhachHang where MaKH = @makh", 
                new SqlParameter("@makh", MaKH)).FirstOrDefault();
            return kq;
        }
        public bool ThemKhachHang(ThongTinDangKyTaiKhoan temp)
        {
            var kh = new KhachHang()
            {
                MaKH = Int32.Parse(temp.SDT.Substring(temp.SDT.Length - 4, temp.SDT.Length-1)),
                HoTen = temp.HoTen,
                SDT = temp.SDT,
                TenDangNhap = temp.TenDangNhap
            };
            db.KhachHangs.Add(kh);
            int kq = db.SaveChanges();
            if (kq > 0) return true;
            return false;
        }
    }
}