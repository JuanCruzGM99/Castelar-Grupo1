using Art_Shop_Data.Model;
using Art_Shop_Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_shop_Website.Controllers
{
    public class HomeController : Controller
    {

        // readonly IProductoData db;
        private BaseDataService<Product> db;


        // GET: Home
        public ActionResult Index()
        {
            var model = db.Get();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string data)
        {
            return View();
        }
        public ActionResult Contacto(string data)
        {
            return View();
        }
        public ActionResult Nosotros(string data)
        {
            return View();
        }



        public HomeController()
        {
            db = new BaseDataService<Product>();

        }


    }
}