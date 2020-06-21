using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BuyFood.Models;
using Website_BuyFood.ViewModel;
using System.Data.SqlClient;

namespace Website_BuyFood.Controllers
{
    public class GioHangController : Controller
    {
        GioHangDao GHD = new GioHangDao();

        // GET: XuLy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TimKiemMonAn(string TenMon)
        {
            MonAnDao mad = new MonAnDao();
            List<MonAn> danhsachmon = mad.KetQuaTimKiem(TenMon);
            return PartialView(danhsachmon);
        }
        public ActionResult ChiTietGioHang(int MaKH)
        {
            List<ThongTinTungMon> danhsachmon = GHD.HienThiGioHang(MaKH);
            return PartialView(danhsachmon);
        }
        public JsonResult ThemVaoGio(ThemVaoGio temp)
        {
            GHD.ThemVaoGioHang(temp);
            return Json(new
            {
                status = true
            });
        }
        public JsonResult XoaMonAnTrongGioHang(ThemVaoGio temp)
        {
            GHD.XoaMonAnTrongGioHang(temp);
            return Json(new
            {
                status = true
            });
        }
        public JsonResult GiamSoLuong(ThemVaoGio temp)
        {
            GHD.GiamSoLuong(temp);
            return Json(new
            {
                status = true
            });
        }
        public JsonResult ThemSoLuong(ThemVaoGio temp)
        {
            GHD.TangSoLuong(temp);
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public ActionResult DatHang(DatHang temp)
        {
            GHD.DatHang(temp);
            return RedirectToAction("Menu","Home");
        }
    }
}