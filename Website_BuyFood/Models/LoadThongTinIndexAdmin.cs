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
            int kq;
            try
            {
               kq = db.Database.SqlQuery<int>("SELECT Sum(tt.TongTien) FROM dbo.ThanhToan tt").FirstOrDefault();
            }
            catch
            {
                kq = 0 ; 
            }
            
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

        public List<DonHangAdmin> GetDonHangAdmins(int maKH)
        {
            try
            {
              
                var model = from a in db.KhachHangs
                            join b in db.GioHangs
                            on a.MaKH equals b.MaKH
                            join c in db.ChiTiet_GioHang
                            on b.MaGioHang equals c.MaGioHang
                            join d in db.MonAns
                            on c.MaMonAn equals d.MaMon
                            where (a.MaKH == maKH && b.TinhTrang == 1) 
                            select new DonHangAdmin()
                            {
                                HoTen = a.HoTen,
                                TenMonAn = d.TenMon,
                                TenDangNhap = a.TenDangNhap,
                                Soluong = c.SoLuong,
                                DonGia = c.DonGia,
                                TrangThaiThanhToan = b.ThanhToan
                            };
                return model.ToList();
            }
            catch
            {
                List<DonHangAdmin> kq = new List<DonHangAdmin>();
                return kq;
            }
        }


    }
}