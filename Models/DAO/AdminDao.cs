using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
namespace Models.DAO
{
    public class AdminDao
    {
        TechNowDBContext db = null;
        public AdminDao()
        {
            db = new TechNowDBContext();
        }
        public Admin GetById(string userName)
        {
            return db.Admins.SingleOrDefault(x => x.Username == userName);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Admins.SingleOrDefault(x => x.Username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {

                if (result.Password == passWord)
                    return 1;
                else
                    return -2;
            }
        }

    }
}

