using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.Framework;
namespace TechNow.Controllers
{
    public class ProductController : Controller
    {
        TechNowDBContext db = new TechNowDBContext();
        // GET: Product
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.ListByCategoryId1 = productDao.ListByCategoryId1(1);
            ViewBag.ListByCategoryId2 = productDao.ListByCategoryId2(2);
            ViewBag.ListByCategoryId3 = productDao.ListByCategoryId3(3);
            ViewBag.ListByCategoryId4 = productDao.ListByCategoryId4(4);
            return View();
        }

        // GET: Product Category
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);  
        }

        public ActionResult Category ( int cateId, int page = 1, int pageSize= 4)
        {
            var Productcategory = new ProductCategoryDao().ViewDetail(cateId);
            ViewBag.ProductCategory = Productcategory;
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryId(cateId,ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
        
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);
            ViewBag.RelatedProduct = new ProductDao().ListRelatedProduct(id);
            return View(product);
        }

        public JsonResult GetProducts(string term)

        {

            List<string> products = db.Products.Where(s => s.ProductName.StartsWith(term))

                .Select(x => x.ProductName).ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

    }
}