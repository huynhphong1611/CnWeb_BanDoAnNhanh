using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                            MaMon = b.MaMon,
                            TenMon = b.TenMon,
                            DonGia = b.DonGia,
                            LinkAnh = b.LinkAnh,
                            SoLuong = a.SoLuong
                        };
            return model.ToList();
        }
        public void ThemVaoGioHang(ThemVaoGio temp)
        {
            db.Database.ExecuteSqlCommand("exec ThemVaoGioHang @makh,@mamon",
                new SqlParameter("makh", temp.MaKH),
                new SqlParameter("mamon", temp.MaMon)
            );
        }
        public void XoaMonAnTrongGioHang(ThemVaoGio temp)
        {
            try
            {
                db.Database.ExecuteSqlCommand("exec XoaMonAnTrongGioHang @makh,@mamon",
                    new SqlParameter("makh", temp.MaKH),
                    new SqlParameter("mamon", temp.MaMon)
                );
            }
            catch
            {

            }

        }
    }
}