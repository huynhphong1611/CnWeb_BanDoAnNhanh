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
    public class TaiKhoanDao
    {
        MyDBContext db = null;
        public TaiKhoanDao()
        {
            db = new MyDBContext();
        }
        public bool KiemTraDangNhap(TaiKhoan tk)
        {
            int kq = db.TaiKhoans.Count(x => x.TenDangNhap == tk.TenDangNhap && x.MatKhau == tk.MatKhau);
            if (kq > 0) return true;
            return false;
        }
        public void DangKyTaiKhoan(ThongTinDangKyTaiKhoan tk)
        {
            db.Database.ExecuteSqlCommand("exec DangKyTaiKhoan @hoten,@sdt,@tendangnhap,@matkhau",
                new SqlParameter("hoten", tk.HoTen),
                new SqlParameter("sdt", tk.SDT),
                new SqlParameter("tendangnhap", tk.TenDangNhap),
                new SqlParameter("matkhau", tk.MatKhau)
            );
        }
        //Huynh kiem tra admin 
        public bool kiemTraAdmin(TaiKhoan tk)
        {
            int kq = db.TaiKhoans.Count(x => x.TenDangNhap == tk.TenDangNhap && x.MatKhau == tk.MatKhau && x.LoaiTaiKhoan == "admin");
            if (kq > 0) return true;
            return false;
        }
    }
}