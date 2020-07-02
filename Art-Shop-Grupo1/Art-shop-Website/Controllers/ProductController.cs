using Art_Shop_Data.Services;
using Art_Shop_Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Art_shop_Website.Services;

namespace Art_shop_Website.Controllers
{
    public class ProductController : BaseController
    {
        private BaseDataService<Product> db;
        private object cart;

        public ProductController()
        {
            db = new BaseDataService<Product>();
        }

        public ActionResult IndexProduct()
        {

            //var i = 0;
            //var result = 15 / i;

            var list = db.Get();
            return View(list);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db.Delete(id.Value);
            if (id == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("IndexProduct");
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            this.CheckAuditPattern(product, true);
            var list = db.ValidateModel(product);
            if (ModelIsValid(list))
                return View(product);
            try
            {
                db.Create(product);
                return RedirectToAction("IndexProduct");

            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(product);
            }

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.GetById(id.Value);
            if (product == null)
            {
                Logger.Instance.LogException(new Exception("Product HttpNotFound"));
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            this.CheckAuditPattern(product);
            var list = db.ValidateModel(product);
            if (ModelIsValid(list))
                return View(product);
            try
            {
                db.Update(product);
                return RedirectToAction("IndexProduct");

            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(product);
            }

        }
    }
}

