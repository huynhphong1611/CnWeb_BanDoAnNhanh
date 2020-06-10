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
        [HttpPost]
        public ActionResult add(MonAn data, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string path = Server.MapPath("/Content/images/" + file.FileName);
                file.SaveAs(path);
                //
                MonAn ins = new MonAn();
                ins.MaMon = context.MonAns.ToList().Count() + 1;
                ins.TenMon = data.TenMon;
                ins.LinkAnh = file.FileName;
                ins.DonGia = data.DonGia;
                context.MonAns.Add(ins);
                context.SaveChanges();
            }
            else
            {
                MonAn ins = new MonAn();
                ins.MaMon = context.MonAns.ToList().Count() + 1;
                ins.TenMon = data.TenMon;
                ins.LinkAnh = "Không có ảnh";
                ins.DonGia = data.DonGia;
                context.MonAns.Add(ins);
                context.SaveChanges();
            }
            return RedirectToAction("index", "home");
        }
    }
}