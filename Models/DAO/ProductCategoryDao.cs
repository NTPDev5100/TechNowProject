using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class ProductCategoryDao
    {
        TechNowDBContext db = null;
        public ProductCategoryDao()
        {
            db = new TechNowDBContext();
        }
        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.CategoryID;
        }
        public bool Update(ProductCategory entity)
        {
            try
            {
                var pdcategory = db.ProductCategories.Find(entity.CategoryID);
                pdcategory.Name = entity.Name;
                pdcategory.MetaTitle = entity.MetaTitle;
                pdcategory.ParentID = entity.ParentID;
                pdcategory.DisplayOrder = entity.DisplayOrder;
                pdcategory.SeoTitle = entity.SeoTitle;
                pdcategory.ModifiedDate = DateTime.Now;
                pdcategory.ModifiedBy = entity.ModifiedBy;
                pdcategory.MetaKeywords = entity.MetaKeywords;
                pdcategory.MetaDescriptions = entity.MetaDescriptions;
                pdcategory.Status = entity.Status;
                pdcategory.ShowOnHome = entity.ShowOnHome;
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
                var pdcategory = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(pdcategory);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<ProductCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public ProductCategory ViewDetail(int id)
        {

            return db.ProductCategories.Find(id);
        }

        //CLient
        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    
    }
}
