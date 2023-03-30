using AssignmentCodeFirstCheckbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentCodeFirstCheckbox.Controllers
{
    public class TestController : Controller
    {
        CompanyContext cc = new CompanyContext();
        // GET: Test

        public ActionResult Index()
        {
            var v = from t in cc.Products
                    select new ProdLVM
                    {
                        ProductId = t.ProductId,
                        ProductName = t.ProductName,
                        ColorCount = t.ProductColors.Count()
                    };
            return View(v.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p,int [] chk)
        {
            this.cc.Products.Add(p);
            this.cc.SaveChanges();

            foreach(int t in chk)
            {
                ProductColor temp = new ProductColor();
                temp.ColorId = t;
                temp.ProductId = p.ProductId;
                this.cc.ProductColors.Add(temp);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [ChildActionOnly]
        public ActionResult GetCheck()
        {
            var v = from t in cc.Colors
                    select new CBoxVM
                    {
                        Value = t.ColorId,
                        Text = t.ColorName,
                        IsSelected = false
                    };
            return View("_CheckListView", v.ToList());
        }
        [ChildActionOnly]
        public ActionResult GetCal(Int64 id)
        {
            var rec = this.cc.Products.Find(id);
            var pc = rec.ProductColors.Select(a => a.ColorId).ToList();
            var v = from t in cc.Colors
                    select new CBoxVM
                    {
                        Value = t.ColorId,
                        Text = t.ColorName,
                        IsSelected = pc.Contains(t.ColorId)
                    };
            ViewBag.Chk = v.ToList();


            return View("_CheckListView", v.ToList());
        }
        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            
                var rec = this.cc.Products.Find(id);
                var c = rec.ProductColors.Select(a => a.ColorId).ToList();
            return View(rec);
            

        }
        [HttpPost]
        public ActionResult Edit(ProductColor rec,Int64[] chk)
        {
            this.cc.Entry(rec).State = System.Data.Entity.EntityState.Modified;
            this.cc.SaveChanges();
            var pclr = this.cc.ProductColors.Where(p => p.ProductId == rec.ProductId).ToList();
            foreach (var c in pclr)
            {
                this.cc.ProductColors.Remove(c);
            }
            foreach (int cid in chk)
            {
                ProductColor temp = new ProductColor();
                temp.ColorId = cid;
                temp.ProductId = rec.ProductId;
                this.cc.ProductColors.Add(temp);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var rec = this.cc.Products.Find(id);
            var c = rec.ProductColors.Select(a => a.ColorId).ToList();
            var v = from t in cc.Colors
                    select new CBoxVM
                    {
                        Value = t.ColorId,
                        Text = t.ColorName,
                        IsSelected = c.Contains(t.ColorId)
                    };
            ViewBag.Chk = v.ToList();


            return View(rec);
            
        }
    }
}