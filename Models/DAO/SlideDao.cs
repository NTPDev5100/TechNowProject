using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.DAO
{
    public class SlideDao
    {
        TechNowDBContext db = null;
        public SlideDao()
        {
            db = new TechNowDBContext();
        }

        public List<Slider> ListAll()
        {
            return db.Sliders.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
        public long Insert(Slider entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Sliders.Add(entity);
            db.SaveChanges();
            return entity.SlideID;
        }

        public bool Update(Slider entity)
        {
            try
            {
                var slider = db.Sliders.Find(entity.SlideID);
                slider.DisplayOrder = entity.DisplayOrder;
                slider.Link = entity.Link;
                slider.Description = entity.Description;
                slider.ModifiedDate = DateTime.Now;
                slider.ModifiedBy = entity.ModifiedBy;
                slider.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public bool Updateimage(Slider entity)
        {
            try
            {
                var slider = db.Sliders.Find(entity.SlideID);
                slider.Image = entity.Image;
                slider.ModifiedDate = DateTime.Now;
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
                var slider = db.Sliders.Find(id);
                db.Sliders.Remove(slider);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<Slider> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Slider> model = db.Sliders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Description.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public Slider ViewDetail(int id)
        {
            return db.Sliders.Find(id);
        }
    }
}
