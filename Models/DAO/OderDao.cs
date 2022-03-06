using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class OderDao
    {
        TechNowDBContext db = null;
        public OderDao()
        {
            db = new TechNowDBContext();
        }

        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        var order = db.Orders.Find(id);
        //        db.Orders.Remove(order);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}


        public List<OrderDetail> ListByOrderId(int orderID)
        {
            var model = db.OrderDetails.Where(x => x.OrderID == orderID).OrderByDescending(x => x.ID).ToList();
            return model;
        }

       
        public Order ViewDetail(int id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Order> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Order> model = db.Orders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
    }
}
