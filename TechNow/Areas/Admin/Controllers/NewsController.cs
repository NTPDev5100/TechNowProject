using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

namespace TechNow.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        TechNowDBContext db = new TechNowDBContext();
        // GET: Admin/News
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new NewsDao();

            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SeachString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(New news, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(news.ImageFile.FileName);
                    string extension = Path.GetExtension(news.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                    news.NewImage = "" + filename;
                    filename = Path.Combine(Server.MapPath("~/Assets/Client/images/news/"), filename);
                    news.ImageFile.SaveAs(filename);
                    var dao = new NewsDao();
                    long id = dao.Insert(news);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "News");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Them tin tuc khong thanh cong");
                    }
                }
                else
                {
                    var dao = new NewsDao();
                    long id = dao.Insert(news);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "News");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Them tin tuc khong thanh cong");
                    }
                }
            }
            return View("Index");
        }

        public ActionResult Details(int id)
        {
            var news = new NewsDao().ViewDetail(id);
            return View(news);
        }

        public ActionResult Edit(int id)
        {
            var news = new NewsDao().ViewDetail(id);
            return View(news);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(New news, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(news.ImageFile.FileName);
                    string extension = Path.GetExtension(news.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                    news.NewImage = "" + filename;
                    filename = Path.Combine(Server.MapPath("~/Assets/Client/images/news/"), filename);
                    news.ImageFile.SaveAs(filename);

                    var resultimage = dao.Updateimage(news);
                    if (resultimage)
                    {
                        return RedirectToAction("Index", "News");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Them tin tuc khong thanh cong");
                    }
                }
                else
                {

                    var result = dao.Update(news);
                    if (result)
                    {
                        return RedirectToAction("Index", "News");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Them tin tuc khong thanh cong");
                    }
                }


            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new NewsDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}