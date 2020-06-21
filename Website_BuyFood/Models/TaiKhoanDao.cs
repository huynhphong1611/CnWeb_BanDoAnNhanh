using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website_BuyFood.Common;
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
        //Huynh them de phan quyen admin
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public bool KiemTraDangNhap(TaiKhoan tk)
        {
            string passhash = CryptoLib.MD5Hash(tk.MatKhau);
            int kq = db.TaiKhoans.Count(x => x.TenDangNhap == tk.TenDangNhap && x.MatKhau == passhash);
            if (kq > 0) return true;
            return false;
        }
        public void DangKyTaiKhoan(ThongTinDangKyTaiKhoan tk)
        {
            db.Database.ExecuteSqlCommand("exec DangKyTaiKhoan @hoten,@sdt,@tendangnhap,@matkhau",
                new SqlParameter("hoten", tk.HoTen),
                new SqlParameter("sdt", tk.SDT),
                new SqlParameter("tendangnhap", tk.TenDangNhap),
                new SqlParameter("matkhau", CryptoLib.MD5Hash(tk.MatKhau))
            );
        }
        //Huynh kiem tra admin 
        public bool kiemTraAdmin(string tenDangNhap,string matKhau, string permission)
        {
            int kq = db.TaiKhoans.Count(x => x.TenDangNhap == tenDangNhap && x.MatKhau == matKhau && x.LoaiTaiKhoan == permission);
            if (kq > 0) return true;
            return false;
        }
    }
}