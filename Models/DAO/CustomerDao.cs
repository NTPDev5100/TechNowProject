using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class CustomerDao
    {
        TechNowDBContext db = null;
        public CustomerDao()
        {
            db = new TechNowDBContext();
        }
       
        public long Insert(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
            return entity.CustomerID;
        }

        public bool Update(Customer entity)
        {
            try
            {
                var customer = db.Customers.Find(entity.CodeCus);
                customer.Email = entity.Email;
                customer.Name = entity.Name;
                customer.Phone = entity.Phone;
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
                var customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Customer ViewDetail(int id)
        {
            return db.Customers.Find(id);
        }
        public IEnumerable<Customer> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Customer> model = db.Customers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Email.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CustomerID).ToPagedList(page, pageSize);
        }
        

        //GetbyId lay email khi user login ben client
        public Customer GetById(string email)
        {
            return db.Customers.SingleOrDefault(x => x.Email == email);
        }

        public int CustomerLogin(int code,string email)
        {
            var result = db.Customers.SingleOrDefault(x => x.Email == email);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if (result.CodeCus == code)
                    return 1;
                else
                    return -1;
            }
        }


        public bool CheckCodeCustomer(int codeCus)
        {
            return db.Customers.Count(x => x.CodeCus == codeCus) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Customers.Count(x => x.Email == email) > 0;
        }

    }
}
