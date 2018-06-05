using LastCakeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LastCakeProject.Controllers
{
    public class AdminController : Controller
    {
        CakeContext db = new CakeContext();
        public ActionResult Index()
        {
            //if(Session["Employee"] != null)
            //{
            //    return View();
            //}
            //return RedirectToAction("Login");
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account account)
        {
            String username = Request.Form["username"];
            String password = Request.Form["password"];
            var Query = (from d in db.Employees
                        where d.username == username && d.password == password
                        select d.employeeId).Take(1);
            //int id = Query;
            return RedirectToAction("Index");
        }

        public ActionResult ViewProduct()
        {
            return View(db.Products.ToList());
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.createAt = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public ActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            return View(product);
        }

        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct([Bind(Include = "productId, productName, productImage, productPrice, productDescription, createAt")] Product product)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {

                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }

        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ViewAllOrder()
        {
            List<Order> list = new List<Order>();

            var Query = from d in db.Orders
                         where d.orderId != 12
                         orderby d.orderId descending
                         select d;
            list.AddRange(Query.Distinct());
            return View(list);
        }
        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder([Bind(Include = "orderId, customerId, customerAddress, customerName, customerPhone, employeeId, totalPrice, status, crateAt")] Order order)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {

                    db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(order);
            }
        }


    }
}