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
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SlideDao();

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
        public ActionResult Create(Slider slider, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(slider.ImageFile.FileName);
                    string extension = Path.GetExtension(slider.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                    slider.Image = "" + filename;
                    filename = Path.Combine(Server.MapPath("~/Assets/Client/images/slider/"), filename);
                    slider.ImageFile.SaveAs(filename);
                    var dao = new SlideDao();
                    long id = dao.Insert(slider);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "Slide");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Them slide khong thanh cong");
                    }
                }
                else
                {
                    var dao = new SlideDao();
                    long id = dao.Insert(slider);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "Slide");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Them slide khong thanh cong");
                    }
                }

            }
            return View("Index");
        }
        public ActionResult Details(int id)
        {
            var slide = new SlideDao().ViewDetail(id);
            return View(slide);
        }
        public ActionResult Edit(int id)
        {
            var slide = new SlideDao().ViewDetail(id);
            return View(slide);
        }
        [HttpPost]
        public ActionResult Edit(Slider slider, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDao();
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(slider.ImageFile.FileName);
                    string extension = Path.GetExtension(slider.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                    slider.Image = "" + filename;
                    filename = Path.Combine(Server.MapPath("~/Assets/Client/images/slider/"), filename);
                    slider.ImageFile.SaveAs(filename);

                    var resultimage = dao.Updateimage(slider);
                    if (resultimage)
                    {
                        return RedirectToAction("Index", "Slide");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Them slide khong thanh cong");
                    }
                }
                else
                {

                    var result = dao.Update(slider);
                    if (result)
                    {
                        return RedirectToAction("Index", "Slide");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Them slide khong thanh cong");
                    }
                }


            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SlideDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}