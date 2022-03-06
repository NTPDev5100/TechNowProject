using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using Models.DAO;

namespace TechNow.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new CustomerDao();

            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SeachString = searchString;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var customer = new CustomerDao().ViewDetail(id);
            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = new CustomerDao().ViewDetail(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var result = dao.Update(customer);
                if (result)
                {
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Cap nhat khach hang khong thanh cong");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CustomerDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}