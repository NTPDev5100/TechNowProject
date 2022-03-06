using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;
using Models.ViewModel;
namespace Models.DAO
{
    public class ProductDao
    {
        TechNowDBContext db = null;
        public ProductDao()
        {
            db = new TechNowDBContext();
        }
        public long Insert(Product entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ProductID;
        }
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ProductID);
                product.ProductCode = entity.ProductCode;
                product.ProductName = entity.ProductName;
                product.MetaTitle = entity.MetaTitle;
                product.Description = entity.Description;
                //product.ProductImage = entity.ProductImage;
                product.MoreImages = entity.MoreImages;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.IncludeVAT = entity.IncludeVAT;
                product.Quantity = entity.Quantity;
                product.CategoryID = entity.CategoryID;
                product.Detail = entity.Detail;
                product.Warranty = entity.Warranty;
                product.CreatedBy = entity.CreatedBy;
                product.ModifiedDate = DateTime.Now;
                product.ModifiedBy = entity.ModifiedBy;
                product.MetaKeywords = entity.MetaKeywords;
                product.MetaDescriptions = entity.MetaDescriptions;
                product.Status = entity.Status;
                product.TopHot = entity.TopHot;
                product.ViewCounts = entity.ViewCounts;
                product.OriginalPrice = entity.OriginalPrice;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public bool Updateimage(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ProductID);
                product.ProductImage = entity.ProductImage;
                product.ModifiedDate = DateTime.Now;
                product.ViewCounts = entity.ViewCounts;
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
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ProductName.Contains(searchString) && x.Status == true);
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }


        //CLient
        public List<Product> ListByCategoryId(int categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 4)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = db.Products.Where(x => x.CategoryID == categoryID && x.Status == true).OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }
        //Ham xu ly hien thi danh sach nhung san pham moi vua ra mat tren trang chu 
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }


        //Ham xu ly hien thi danh sach nhung san pham hot tren trang chu 
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now && x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }


        //Ham xu ly san pham lien trong trang chi tiet san pham
        public List<Product> ListRelatedProduct(int productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ProductID != productId && x.CategoryID == product.CategoryID && x.Status == true).ToList();
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
        public List<Product> ListByCategoryId1(int categoryID)
        {
            categoryID = 1;
            var model = db.Products.Where(x => x.CategoryID == categoryID && x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
            return model;
        }
        public List<Product> ListByCategoryId2(int categoryID)
        {
            categoryID = 2;
            var model = db.Products.Where(x => x.CategoryID == categoryID && x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
            return model;
        }
        public List<Product> ListByCategoryId3(int categoryID)
        {
            categoryID = 3;
            var model = db.Products.Where(x => x.CategoryID == categoryID && x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
            return model;
        }
        public List<Product> ListByCategoryId4(int categoryID)
        {
            categoryID = 4;
            var model = db.Products.Where(x => x.CategoryID == categoryID && x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
            return model;
        }
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.ProductName.Contains(keyword) && x.Status == true).Select(x => x.ProductName).ToList();
        }
        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 10)
        {
            totalRecord = db.Products.Where(x => x.ProductName == keyword ).Count();
            var model = (from a in db.Products
                         join b in db.ProductCategories
                         on a.CategoryID equals b.CategoryID
                         where a.ProductName.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ProductID,
                             Images = a.ProductImage,
                             Name = a.ProductName,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

    }
}
