using Art_Shop_Data.Services;
using Art_Shop_Data.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Art_shop_Website.Services;

namespace Art_shop_Website.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public ActionResult Create(Product product, HttpPostedFileBase newimage)
        {
            this.CheckAuditPattern(product, true);
            var list = db.ValidateModel(product);
            if (ModelIsValid(list))
                return View(product);
            try
            {
                if (newimage.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(newimage.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/image"), _FileName);
                    newimage.SaveAs(_path);
                    product.Image = _FileName;
                }
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
        public ActionResult Edit(Product product, HttpPostedFileBase file)
        {
            this.CheckAuditPattern(product);
            var list = db.ValidateModel(product);
            if (ModelIsValid(list))
                return View(product);
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/image"), _FileName);
                    file.SaveAs(_path);
                    product.Image = _FileName;
                }
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

