using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;

namespace TechNow.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult News()
        {
            var newsDao = new NewsDao();
            ViewBag.NewNews = newsDao.ListNewNews(4);
            ViewBag.ListFeatureNews = newsDao.ListFeatureNews(4);
            ViewBag.ListKhoaHoc = newsDao.ListCate(3, 1);
            ViewBag.ListReview = newsDao.ListCate(3, 2);
            ViewBag.ListThuThuat = newsDao.ListCate(3, 3);
            ViewBag.ListTinCongNghe = newsDao.ListCate(3, 4);
            ViewBag.category = new NewsCategoryDao().ListAll1();
            return View();
        }

        public ActionResult DetailNews(int newsId)
        {
            var news = new NewsDao().ViewDetail(newsId);
            ViewBag.Category = new NewsCategoryDao().ViewDetail(news.NewCategoryID.Value);
            ViewBag.RelatedNews = new NewsDao().ListRelatedNews(newsId);
            ViewBag.NewNews = new NewsDao().ListNewNews(5);
            ViewBag.ListFeatureNews = new NewsDao().ListFeatureNews(5);
            ViewBag.cateNews = new NewsCategoryDao().ListAll1();
            return View(news);
        }

        public ActionResult CategoryNews(int newcateId)
        {
            var category = new NewsCategoryDao().ViewDetail(newcateId);
            ViewBag.NewCategory = category;
            var model = new NewsDao().ListByCategoryIDNews(newcateId);
            return View(model);
        }
        



    }
}