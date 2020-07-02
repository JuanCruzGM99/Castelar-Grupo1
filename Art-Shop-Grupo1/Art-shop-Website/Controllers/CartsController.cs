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
          
            return View((List<CartItem>)Session["cart"]);
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
              
                cart.ItemCount = 1;
                cart.CartDate = DateTime.Now;
                cart.CreatedOn = DateTime.Now;
                cart.ChangedOn = DateTime.Now;
         
                
                cartitem.ProductId = id.Value;
                cartitem.Price = producto.Price;
                cartitem.Quantity = 1;
                cartitem.CartId = cart.Id;
        
                cartitem.CreatedOn = DateTime.Now;
                cartitem.ChangedOn = DateTime.Now;
                
              

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

                cart.Cookie = Session.SessionID;
                db.Carts.Add(cart);
                db.SaveChanges();

                cartitem.CartId = cart.Id;
                db.CartsItem.Add(cartitem);
                db.SaveChanges();


            }
            return RedirectToAction("Index");
           
         
        }




       
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
            CartItem cartitem = db.CartsItem.Find(id);
            if (cartitem == null)
            {
                return HttpNotFound();
            }
            return View(cartitem);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            CartItem cartitem = db.CartsItem.Find(id);
            db.CartsItem.Remove(cartitem);
            db.SaveChanges();
            

            List<CartItem> li = (List<CartItem>)Session["cart"];
            li.RemoveAll(x => x.Id == cartitem.Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            ViewBag.cart = li.Count();
            
            
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
