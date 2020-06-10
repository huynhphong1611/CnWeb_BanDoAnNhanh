using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BuyFood.Models;

namespace Website_BuyFood.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private MyDBContext context = new MyDBContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var modelSanPham = context.MonAns.Where(x => x.TenMon != null).ToList();
            return View(modelSanPham);

        }

        public ActionResult Login()
        {
            return View();
        }
    }
}