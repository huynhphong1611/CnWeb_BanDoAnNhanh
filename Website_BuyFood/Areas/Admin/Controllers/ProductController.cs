﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BuyFood.Models;
using Website_BuyFood.Areas.Admin.Models;

namespace Website_BuyFood.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private MyDBContext context = new MyDBContext();
        [CheckPermission(permissionAdmin = "admin")]
        // GET: Admin/Product
        public ActionResult Index()
        {
            var modelSanPham = context.MonAns.Where(x => x.TenMon != null).ToList();
            return View(modelSanPham);
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
            return RedirectToAction("index", "product");
        }
        public ActionResult viewedit(int? maMon)
        {
            if (maMon != null)
                return PartialView("_Viewedit", context.MonAns.Where(s => s.MaMon == maMon).FirstOrDefault());
            else
                return PartialView("_Viewedit", context.MonAns.Where(s => s.MaMon == 2).FirstOrDefault());
        }

        public ActionResult delete(int? maMon)
        {
            // xóa sản phẩm
            context.MonAns.Remove(context.MonAns.Find(maMon));
            context.SaveChanges();
            return RedirectToAction("index", "product");
        }
        public ActionResult edit(MonAn data, HttpPostedFileBase file)
        {
            var monAn = context.MonAns.FirstOrDefault(c => c.MaMon.Equals(1));
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
            return RedirectToAction("index", "product");
        }
        public ActionResult detail(MonAn data)
        {
            return RedirectToAction("index", "product");
        }
    }
}
