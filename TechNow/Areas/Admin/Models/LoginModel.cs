using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechNow.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}