using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BuyFood.Common;
using Website_BuyFood.Models;
using Website_BuyFood.ViewModel;
using Website_BuyFood.Areas.Admin.Controllers;

namespace Website_BuyFood.Controllers
{
    public class HomeController : Controller
    {
        private MyDBContext context = new MyDBContext();
      
        public ActionResult Index()
        {
            return View();
        }
       
        public JsonResult DangNhap(TaiKhoan tk)
        {
            TaiKhoanDao tkd = new TaiKhoanDao();
            if (tkd.kiemTraAdmin(tk))
            {
                //Huynh chuyen huong sang admin 
                var userSesstion = new UserLogin();
                userSesstion.TenDangNhap = tk.TenDangNhap;
                userSesstion.LoaiTaiKhoan = "admin";
                Session.Add(CommonConstants.USER_SESSION, userSesstion);
                return Json(new
                {
                    status = true
                });


            } else if (tkd.KiemTraDangNhap(tk) == true && ModelState.IsValid)
            {
                var userSesstion = new UserLogin();
                userSesstion.TenDangNhap = tk.TenDangNhap;
                Session.Add(CommonConstants.USER_SESSION, userSesstion);
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
            
        }
        public JsonResult DangKy(ThongTinDangKyTaiKhoan tk)
        {
            TaiKhoanDao tkd = new TaiKhoanDao();           
            if (ModelState.IsValid)
            {
                tkd.DangKyTaiKhoan(tk);
                return Json(new
                {
                    status = true
                });                                    
            }
            return Json(new
            {
                status = false
            });
        }
        public ActionResult Menu()
        {
           
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }
        public ActionResult LoadLaiSauKhiDangNhap()
        {           
            return PartialView();
        }
    }
}