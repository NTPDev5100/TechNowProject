using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDetailDao
    {
        TechNowDBContext db = null;
        public OrderDetailDao()
        {
            db = new TechNowDBContext();
        }


        
        public OrderDetail ViewDetail(int id)
        {
            return db.OrderDetails.Find(id);
        }

    }
}
