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
using Microsoft.Ajax.Utilities;

namespace Art_shop_Website.Controllers
{
    public class CartsController : Controller
    {
        private ArtShopDbContext db = new ArtShopDbContext();

        // GET: Carts
        public ActionResult Index()
        {
            if ((List<CartItem>)Session["cart"] != null)
            {
                return View((List<CartItem>)Session["cart"]);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
          
            CartItem cartitem = new CartItem();
            
            Product producto = db.Product.Find(id);


            if (ModelState.IsValid)
            {
              
                      
                
              

                if (Session["cart"] == null)
                {
                    Cart cart = new Cart();
                    List<CartItem> li = new List<CartItem>();

                    li.Add(cartitem);
                    Session["cart"] = li;
                    ViewBag.cart = li.Count();
                    Session["count"] = 1;

                    cart.ItemCount = 1;
                    cart.CartDate = DateTime.Now;
                    cart.CreatedOn = DateTime.Now;
                    cart.ChangedOn = DateTime.Now;
                    cart.Cookie = Session.SessionID;
                    db.Carts.Add(cart);
                    db.SaveChanges();

                    cartitem.ProductId = id.Value;
                    cartitem.Price = producto.Price;
                    cartitem.Quantity = 1;
                    cartitem.CartId = cart.Id;
                    cartitem.CreatedOn = DateTime.Now;
                    cartitem.ChangedOn = DateTime.Now;
                }
                else
                {

                    CartItem cartitem_ant;
                    List<CartItem> li = (List<CartItem>)Session["cart"];
                    foreach (var item in li)
                    {
                       cartitem_ant = db.CartsItem.Find(item.Id);
                        cartitem.CartId = cartitem_ant.CartId;
                    }

                        cartitem.ProductId = id.Value;
                    cartitem.Price = producto.Price;
                    cartitem.Quantity = 1;
                
                    cartitem.CreatedOn = DateTime.Now;
                    cartitem.ChangedOn = DateTime.Now;



                    li.Add(cartitem);
                    Session["cart"] = li;
                    ViewBag.cart = li.Count();
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;

                }

             

       
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
        [Authorize]
        public ActionResult CreateOrder()
        {
            List<CartItem> items = (List<CartItem>)Session["cart"];

            Order order = new Order("");

            OrderNumber orderNumber = db.OrdersNumbers.FirstOrDefault();
            if(orderNumber == null)
            {
                orderNumber = new OrderNumber();
                orderNumber.Number = 2;
                db.OrdersNumbers.Add(orderNumber);
                order.OrderNumber = 1;

            }
            else
            {
                order.OrderNumber = orderNumber.Number;
                orderNumber.Number++;
                db.Entry(orderNumber).State = EntityState.Modified;
            }
            order.OrderDate = DateTime.Now;
            
            order.Items = new List<OrderDetail>();
            foreach(CartItem item in items)
            {
                OrderDetail detail = new OrderDetail(item.ProductId, item.Price, item.Quantity, "");
                order.Items.Add(detail);
                order.TotalPrice = detail.Price * (double)detail.Quantity;
                order.ItemCount += detail.Quantity;
            }
            db.Orders.Add(order);

            db.SaveChanges();
            return View(order);
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

     
     
        public ActionResult Vaciar()
        {
            List<CartItem> li = (List<CartItem>)Session["cart"];
          
            foreach (var item in li)
           {
                CartItem cartitem = db.CartsItem.Find(item.Id);
                db.CartsItem.Remove(cartitem);
                db.SaveChanges();
              

            }

           // li.RemoveAll(x => x.Id == cartitem.Id);

            Session["cart"] = null;
            Session["count"] = 0;
            ViewBag.cart = li.Count();


            return RedirectToAction("Index", "Home");

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
