using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BuyFood.Common;
using Website_BuyFood.Models;

namespace Website_BuyFood.Areas.Admin.Models
{
    public class CheckPermissionAttribute : AuthorizeAttribute
    {
        public string permissionAdmin { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            UserLogin userLogin = (UserLogin)HttpContext.Current.Session[Common.CommonConstants.ADMIN_SESSION];
            TaiKhoanDao tkDao = new TaiKhoanDao();
            if (userLogin != null && tkDao.kiemTraAdmin(userLogin.TenDangNhap, userLogin.MatKhau, permissionAdmin))
            {
                //Huynh lay duoc tai khoan dang nhap trong 1 phien làm việc
                // và kiem tra xem cso phai admin k 
                return true;
                
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Areas/Admin/Views/Home/Login.cshtml"
            };


        }
    }
}