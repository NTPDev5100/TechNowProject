using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class RevenueStatisticViewModel
    {
        public int ID { set; get; }
        public decimal? Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Quantity { get; set; }
    }
}
