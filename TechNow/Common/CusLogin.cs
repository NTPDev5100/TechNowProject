using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechNow.Common
{
    [Serializable]
    public class CusLogin
    {
        public int CustomerID { get; set; }
        public string Email { get; set; }
        public int CodeCus { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
    }
}