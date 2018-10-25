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
                if(db.SaveChanges() > 0)
                {
                    return RedirectToAction("Index","Product");
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
    }
}