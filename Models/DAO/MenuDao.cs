using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class MenuDao
    {
        TechNowDBContext db = null;
        public MenuDao()
        {
            db = new TechNowDBContext();
        }

        public List<Menu> ListByGroudId(int groupId)
        {
            return db.Menus.Where(x => x.MenuTypeID == groupId && x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        }

        public long Insert(Menu entity)
        {
            entity.Target = "_self";
            db.Menus.Add(entity);
            db.SaveChanges();
            return entity.MenuID;
        }

        public bool Update(Menu entity)
        {
            try
            {
                var menu = db.Menus.Find(entity.MenuID);
                menu.Text = entity.Text;
                menu.Link = entity.Link;
                menu.DisplayOrder = entity.DisplayOrder;
                menu.Status = entity.Status;
                menu.MenuTypeID = entity.MenuTypeID;
                menu.MenuParentID = entity.MenuParentID;
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
                var menu = db.Menus.Find(id);
                db.Menus.Remove(menu);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public Menu ViewDetail(int id)
        {
            return db.Menus.Find(id);
        }

        public IEnumerable<Menu> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Menu> model = db.Menus;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Text.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MenuID).ToPagedList(page, pageSize);
        }

    }
}
