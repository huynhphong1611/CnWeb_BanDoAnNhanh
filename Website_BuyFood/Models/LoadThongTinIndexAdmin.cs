using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_BuyFood.Models
{
    public class LoadThongTinIndexAdmin
    {

        MyDBContext db = null;
        public LoadThongTinIndexAdmin()
        {
            db = new MyDBContext();
        }
        public int tongDoangThu()
        {
            int kq = db.Database.SqlQuery<int>("SELECT Sum(tt.TongTien) FROM dbo.ThanhToan tt").FirstOrDefault();
            return kq;
        }
        public int soNguoiDatHang()
        {
            int kq = db.Database.SqlQuery<int>("SELECT Count (gh.MaKH) from dbo.GioHang gh").FirstOrDefault();
            return kq;
        }
        public int soSanPhamDaBan()
        {
            int kq = db.Database.SqlQuery<int>("SELECT Count(ma.MaMon) from dbo.GioHang gh, dbo.ChiTiet_GioHang ctgh, dbo.MonAn ma WHERE gh.TinhTrang = 1 AND gh.MaGioHang = ctgh.MaGioHang AND ctgh.MaMonAn = ma.MaMon").FirstOrDefault();
            return kq;
        }
        public int soNguoiDangKi()
        {
           
            int kq = db.Database.SqlQuery<int>(" SELECT Count(kh.MaKH) FROM dbo.KhachHang kh").FirstOrDefault();
            return kq;
        }
        public int soSanPhamHienTai()
        {
            
            int kq = db.Database.SqlQuery<int>(" SELECT Count(ma.MaMon) FROM dbo.MonAn ma").FirstOrDefault();
            return kq;
        }
        public List<KhachHang> GetKhachHangs()
        {
            var model = db.KhachHangs.Where(x => x.TenDangNhap != null).ToList();
            return model;
        }
        
    }
}