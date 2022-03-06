using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class MenuTypeDao
    {
        TechNowDBContext db = null;
        public MenuTypeDao()
        {
            db = new TechNowDBContext();
        }
        public long Insert(MenuType entity)
        {
            db.MenuTypes.Add(entity);
            db.SaveChanges();
            return entity.MenuTypeID;
        }

        public bool Update(MenuType entity)
        {
            try
            {
                var menutype = db.MenuTypes.Find(entity.MenuTypeID);
                menutype.MenuName = entity.MenuName;
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
                var menutpye = db.MenuTypes.Find(id);
                db.MenuTypes.Remove(menutpye);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public MenuType ViewDetail(int id)
        {
            return db.MenuTypes.Find(id);
        }
        public IEnumerable<MenuType> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<MenuType> model = db.MenuTypes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MenuName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MenuTypeID).ToPagedList(page, pageSize);
        }
    }
}
