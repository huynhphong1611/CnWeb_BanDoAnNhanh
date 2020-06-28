using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BuyFood.Areas.Admin.Models;
using Website_BuyFood.Common;
using Website_BuyFood.Models;

namespace Website_BuyFood.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private MyDBContext context = new MyDBContext();
        // GET: Admin/Home

        [CheckPermission(permissionAdmin = "admin")]
        public ActionResult Index()
        {
            var modelSanPham = context.MonAns.Where(x => x.TenMon != null).ToList();
            return View(modelSanPham);
        }
        [HttpPost]
        public ActionResult Login(TaiKhoanDao taiKhoanDao)
        {
            if (taiKhoanDao != null)
            {
                //Huynh them tai khoan nguoi dung nhap vao 1 phien làm viec 
                var userSesstion = new UserLogin();
                userSesstion.TenDangNhap = taiKhoanDao.TenDangNhap;
                userSesstion.MatKhau = taiKhoanDao.MatKhau;
                Session.Add(CommonConstants.ADMIN_SESSION, userSesstion);
                // dang nhap dung tra ve trang homw
                return RedirectToAction("Index", "Home");
            }
            return View();


        }
        public ActionResult Login()
        {
            return View();
        }
    }
        
}