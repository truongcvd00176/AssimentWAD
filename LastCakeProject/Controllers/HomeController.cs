using LastCakeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LastCakeProject.Controllers
{
    public class HomeController : Controller
    {
        CakeContext db = new CakeContext();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult ProductDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Product> list = new List<Product>();

            var Query = (from d in db.Products
                         orderby d.productId descending
                         select d).Take(7);
            list.AddRange(Query.Distinct());
            Product product = db.Products.Find(id);
            list.Add(product);
            return View(list);
        }




        public ActionResult AddOder(int id)
        {
            Session["pro"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddOder(Order order)
        {

            Customer customer = db.Customers.Find(1);
            Customer cus = new Customer();
            cus.username = customer.username;
            cus.password = customer.password;
            cus.customerName = order.customerName;
            cus.customerEmail = customer.customerEmail;
            cus.customerAddress = order.customerAddress;
            cus.customerPhone = order.customerPhone;
            cus.createAt = DateTime.Now;
            db.Customers.Add(cus);
            db.SaveChanges();

            Product product = db.Products.Find(Session["pro"]);
            order.createAt = DateTime.Now;
            order.customerId = cus.customerId;
            order.employeeId = 1;
            order.totalPrice = product.productPrice;
            db.Orders.Add(order);
            db.SaveChanges();

            OrderDetail orderDetail = new OrderDetail();
            orderDetail.productId = product.productId;
            orderDetail.quantity = 1;
            orderDetail.price = product.productPrice;
            orderDetail.orderId = order.orderId;
            db.OrderDetails.Add(orderDetail);
            db.SaveChanges();
            Session["pro"] = 0;
            return RedirectToAction("Index");

        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult CustomeLogin(string username, string password)
        {


            return View();
        }



        [HttpGet]
        public ActionResult CustomeRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomeRegister(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.createAt = DateTime.Now;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}