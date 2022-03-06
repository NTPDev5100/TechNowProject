using TechNow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using System.Configuration;
using Common;

namespace TechNow.Controllers
{
    public class ShoppingCartController : Controller
    {
        TechNowDBContext _db = new TechNowDBContext();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCard(int id)
        {
            var pro = _db.Products.SingleOrDefault(s => s.ProductID == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            } 
            return RedirectToAction("ShowtoCart","ShoppingCart");
        }

        public ActionResult ShowtoCart()
        {
           
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["Product_ID"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowtoCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowtoCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if(cart != null)
            
                total_item = cart.Total_Quantity_Cart();
                ViewBag.QuantityCart = total_item;
                return PartialView("BagCart");
            
        }

        public ActionResult Shopping_Success()
        {
            return View();
        }

        //method checkout
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order _order = new Order();
                _order.CreatedDate = DateTime.Now;
                _order.ShipName = form["CusName"];
                //_order.CodeCus =int.Parse(form["CodeCustomer"]);
                _order.ShipAddress = form["Address_Delivery"];
                _order.ShipMobile = form["Phone"];
                _order.ShipEmail = form["Email"];
                _order.Total = cart.Total_Money();
                _db.Orders.Add(_order);
                foreach(var item in cart.Items)
                {
                    OrderDetail _order_Detail = new OrderDetail();
                    _order_Detail.OrderID = _order.OrderID;
                    _order_Detail.ProductID = item.Shopping_Product.ProductID;
                    _order_Detail.Price = item.Shopping_Product.Price;
                    _order_Detail.Quantity = item.Quantity;
                    _db.OrderDetails.Add(_order_Detail);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", form["CusName"]);
                content = content.Replace("{{Phone}}", form["Phone"]);
                content = content.Replace("{{Email}}", form["Email"]);
                content = content.Replace("{{Address}}", form["Address_Delivery"]);
                content = content.Replace("{{Total}}", _order.Total.ToString());
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(form["Email"], "New Order from TechNow Project Shop", content);
                new MailHelper().SendMail(toEmail, "New Order from TechNow Project Shop", content);
                _db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("Shopping_Success", "ShoppingCart");
            }
            catch
            {
                return Content("Error Checkout.Please information of Customer...");

            }
        }
    }
}