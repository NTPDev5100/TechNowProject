using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models.DAO
{
    public class NewsCategoryDao
    {
        TechNowDBContext db = null;
        public NewsCategoryDao()
        {
            db = new TechNowDBContext();
        }

        public List<NewCategory> ListAll1()
        {
            return db.NewCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public NewCategory ViewDetail(int id)
        {
            return db.NewCategories.Find(id);
        }


    }
}
