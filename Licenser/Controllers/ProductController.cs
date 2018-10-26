using Licenser.Context;
using Licenser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Licenser.Controllers
{
    public class ProductController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ViewBag.Message = "Something Went Wrong!!!!!!";
                }
            }
            return View();
        }
        public JsonResult listProduct()
        {
            List<Product> pdt = db.Products.ToList();
            return Json(pdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product pro = db.Products.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View(pro);
        }
        [HttpPost]
        public JsonResult Edit(Product prod)
        {
            Product pro = db.Products.Find(prod.ProductId);
            if (ModelState.IsValid)
            {
              
                pro.ProductId = prod.ProductId;
                pro.Name = prod.Name;
                pro.Description = prod.Description;
                pro.HomePageUrl = prod.HomePageUrl;
                pro.DownloadUrl = prod.DownloadUrl;
                pro.Version = prod.Version;
                pro.Status = prod.Status;
                if (db.SaveChanges() > 0)
                {
                   
                    return Json(new { result = true, message="Successfully Changed" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = false, message = "No Changes" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { message="Validation Error" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int ProductId)
        {
            Product pro = db.Products.Find(ProductId);
            db.Products.Remove(pro);
            if (db.SaveChanges() > 0)
            {
                return Json(new { result = true, message = "Successfully Deleted" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false, message = "No Changes" }, JsonRequestBehavior.AllowGet);
            }            
        }
    }
}