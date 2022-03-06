using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class NewsDao
    {
        TechNowDBContext db = null;
        public NewsDao()
        {
            db = new TechNowDBContext();
        }
        public long Insert(New entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.News.Add(entity);
            db.SaveChanges();
            return entity.NewID;
        }

        public bool Update(New entity)
        {
            try
            {
                var news = db.News.Find(entity.NewID);
                news.Title = entity.Title;
                news.MetaTitle = entity.MetaTitle;
                news.Description = entity.Description;
                //news.NewImage = entity.NewImage;
                news.NewCategoryID = entity.NewCategoryID;
                news.Detail = entity.Detail;


                news.CreatedBy = entity.CreatedBy;
                news.ModifiedDate = DateTime.Now;
                news.ModifiedBy = entity.ModifiedBy;
                news.MetaKeywords = entity.MetaKeywords;
                news.MetaDescriptions = entity.MetaDescriptions;
                news.Status = entity.Status;
                news.TopHot = entity.TopHot;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public bool Updateimage(New entity)
        {
            try
            {
                var news = db.News.Find(entity.NewID);
                news.NewImage = entity.NewImage;
                news.ModifiedDate = DateTime.Now;
                news.ViewCount = entity.ViewCount;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var news = db.News.Find(id);
                db.News.Remove(news);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<New> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<New> model = db.News;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString) );
            }
            return model.OrderByDescending(x => x.CreatedDate ).ToPagedList(page, pageSize);
        }

        //Client
        public List<New> ListByCategoryIDNews(int categoryID)
        {

            var model = db.News.Where(x => x.NewCategoryID == categoryID && x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
            return model;
        }

        //Ham xu ly hien thi danh sach nhung bai viet moi

        public List<New> ListNewNews(int top)
        {
            return db.News.Where(x => x.Status == true).OrderByDescending(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<New> ListRelatedNews(int id)
        {
            var news = db.News.Find(id);
            return db.News.Where(x => x.NewID != id && x.NewCategoryID == news.NewCategoryID && x.Status == true).ToList();
        }

        public New ViewDetail(int id)
        {
            return db.News.Find(id);
        }

        //Ham xu ly hien thi danh sach nhung bai viet hot tren trang chu 
        public List<New> ListFeatureNews(int top)
        {
            return db.News.Where(x => x.TopHot != null && x.TopHot > DateTime.Now && x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<New> ListCate(int top, int id)
        {
            var cateNews = db.News.Find(id);
            return db.News.Where(x => x.NewCategoryID == cateNews.NewCategoryID && x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<New> ListNews(int top, int id)
        {
            var news = db.News.Find(id);
            return db.News.Where(x => x.NewCategoryID != news.NewCategoryID && x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }



        //Ham xu ly bai viet trong trang chi tiet cua bai viet


    }
}
