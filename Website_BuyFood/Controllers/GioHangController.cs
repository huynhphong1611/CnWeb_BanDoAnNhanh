using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BuyFood.Models;
using Website_BuyFood.ViewModel;

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
        
    }
}