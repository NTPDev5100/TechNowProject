using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.Framework;

namespace TechNow.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new OderDao();

            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SeachString = searchString;
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var order = new OderDao().ViewDetail(id);
            ViewBag.ListByOrderId = new OderDao().ListByOrderId(id);
            return View(order);
        }
        
    }
}