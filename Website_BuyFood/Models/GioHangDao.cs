using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_BuyFood.ViewModel;

namespace Website_BuyFood.Models
{
    public class GioHangDao
    {
        MyDBContext db = null;
        public GioHangDao()
        {
            db = new MyDBContext();
        }
        public List<ThongTinTungMon> HienThiGioHang(int MaKH)
        {
            GioHang temp = db.GioHangs.Find(MaKH);
            var model = from a in db.ChiTiet_GioHang
                        join b in db.MonAns
                        on a.MaMonAn equals b.MaMon
                        where a.MaGioHang == temp.MaGioHang
                        select new ThongTinTungMon()
                        {
                            TenMon = b.TenMon,
                            DonGia = b.DonGia,
                            LinkAnh = b.LinkAnh,
                            SoLuong = a.SoLuong
                        };
            return model.ToList();
        }
        public bool ThemGioHang(int makh)
        {
            var giohang = new GioHang()
            {
                MaKH = makh,
            };
            db.GioHangs.Add(giohang);
            int kq = db.SaveChanges();
            if (kq > 0) return true;
            return false;
        }
    }
}