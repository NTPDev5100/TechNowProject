using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models.DAO
{
    public class StatisticDao
    {
        TechNowDBContext db = null;
        public StatisticDao()
        {
            db = new TechNowDBContext();
        }


        public IEnumerable<GetRevenueStatistic_Result> GetRevenueStatistic(string fromDate, string toDate)
        {
            return db.GetRevenueStatistic(fromDate, toDate);
        }
    }
}
