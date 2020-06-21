using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        public ActionResult viewedit(int? maMon)
        {
            if(maMon != null)
                return PartialView("_Viewedit", context.MonAns.Where(s => s.MaMon == maMon).FirstOrDefault());
            else   
                return PartialView("_Viewedit", context.MonAns.Where(s => s.MaMon == 1).FirstOrDefault());
        }

        public ActionResult delete(int? maMon)
        {
            context.MonAns.Remove(context.MonAns.Find(maMon));
            context.SaveChanges();
            return RedirectToAction("index", "home");
        }
        public ActionResult edit(MonAn data,HttpPostedFileBase file)
        {
            var monAn = context.MonAns.FirstOrDefault(c => c.MaMon.Equals(data.MaMon));
            if (file != null)
            {
                if (monAn != null)
                {
                    string path = Server.MapPath("/Content/images/" + file.FileName);
                    file.SaveAs(path);

                    monAn.TenMon = data.TenMon;
                    monAn.DonGia = data.DonGia;
                    monAn.LinkAnh = file.FileName;
                    context.SaveChanges();
                }
            }
            else
            {
                if (monAn != null)
                {
                    monAn.TenMon = data.TenMon;
                    monAn.DonGia = data.DonGia;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("index", "home");
        }
    }
}