using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BuyFood.Models;
using Website_BuyFood.Areas.Admin.Models;

namespace Website_BuyFood.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private MyDBContext context = new MyDBContext();
        [CheckPermission(permissionAdmin = "admin")]
        // GET: Admin/Order
        public ActionResult Index()
        {
            var modelSanPham = context.MonAns.Where(x => x.TenMon != null).ToList();
            return View(modelSanPham);
        }
    }
}