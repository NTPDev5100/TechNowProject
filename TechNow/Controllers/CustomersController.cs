using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechNow.Model;
using Models.Framework;
using Models.DAO;
using TechNow.Common;

namespace TechNow.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        TechNowDBContext _db = new TechNowDBContext();


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer model)
        {

            if(ModelState.IsValid)
            {
                var dao = new CustomerDao();
                if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email already used, please enter another email");
                }
                else 
                {
                    var cus = new Customer();
                    cus.CodeCus = model.CodeCus;
                    cus.Email = model.Email;
                    cus.Name = model.Name;
                    cus.Phone = model.Phone;
                    var result = dao.Insert(cus);
                    if(result > 0)
                    {
                        ViewBag.SuccessCus = "Successfully Create";
                        model = new Customer();
                        TempData["Success"] = "Successfully Create ";
                        return RedirectToAction("ShowtoCart", "ShoppingCart");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Can't create account");
                    }
                }
            }
            return View(model);
        }

        //GET : Customer Login
        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerLogin(LoginCustomer model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var result = dao.CustomerLogin(model.CodeCus, model.Email);
                if (result == 1)
                {
                    var customer = dao.GetById(model.Email);
                    var cusSession = new CusLogin();
                    cusSession.Email = customer.Email;
                    cusSession.CustomerID = customer.CustomerID;
                    cusSession.CodeCus = customer.CodeCus;
                    cusSession.Phone = customer.Phone;
                    cusSession.Name = customer.Name;
                    Session.Add(CommonConstants.CUSTOMER_SESSTION, cusSession);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Incorrect email");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect Password");
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.CUSTOMER_SESSTION] = null;
            return Redirect("/");
        }
    }
}