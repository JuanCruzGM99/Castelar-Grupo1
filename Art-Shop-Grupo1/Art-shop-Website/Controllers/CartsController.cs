using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Art_Shop_Data.Model;
using Art_Shop_Data.Services;

namespace Art_shop_Website.Controllers
{
    public class CartsController : Controller
    {
        private ArtShopDbContext db = new ArtShopDbContext();

        // GET: Carts
        public ActionResult Index()
        {
            return View(db.Carts.ToList());
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create(int? id)
        {
            Cart cart = new Cart();
            CartItem cartitem = new CartItem();
            
            Product producto = db.Product.Find(id);


            if (ModelState.IsValid)
            {
                cart.Id = 1;
                cart.ItemCount = 1;
                cart.CartDate = DateTime.Now;
                cart.CreatedOn = DateTime.Now;
                cart.ChangedOn = DateTime.Now;
                cart.Cookie = "1";
                
                cartitem.ProductId = id.Value;
                cartitem.Price = (float)producto.Price;
                cartitem.Quantity = 1;
                cartitem.CartId = cart.Id;
        
                cartitem.CreatedOn = DateTime.Now;
                cartitem.ChangedOn = DateTime.Now;

                db.Carts.Add(cart);
                db.SaveChanges();

                //cartitem.Id = 13;
                cartitem.CartId = cart.Id;
                db.CartsItem.Add(cartitem);
                db.SaveChanges();

                if (Session["cart"] == null)
                {
                    List<CartItem> li = new List<CartItem>();

                    li.Add(cartitem);
                    Session["cart"] = li;
                    ViewBag.cart = li.Count();
                    Session["count"] = 1;
                }
                else
                {
                    List<CartItem> li = (List<CartItem>)Session["cart"];
                    li.Add(cartitem);
                    Session["cart"] = li;
                    ViewBag.cart = li.Count();
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;

                }
             //  return RedirectToAction("Index");
            }
            return View((List<CartItem>)Session["cart"]);
            //return View(cart);
        }




        // POST: Carts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        /*  [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create(Product producto)
          {
              Cart cart = new Cart();
              CartItem cartitem = new CartItem();

              if (ModelState.IsValid)
              {

                  cart.ItemCount = 1;
                  cart.CartDate = DateTime.Now;
                  cartitem.ProductId = producto.Id;
                  //cartitem.Price = producto.Price;
                  cartitem.Quantity = 1;
                  cartitem.Id = cart.Id;
                  db.Carts.Add(cart);
                  db.CartsItem.Add(cartitem);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }

              return View(cart);
          }
        */
        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        public ActionResult ViewProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product producto = db.Product.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Carts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cookie,CartDate,ItemCount,CreatedOn,CreatedBy,ChangedOn,ChangedBy")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
