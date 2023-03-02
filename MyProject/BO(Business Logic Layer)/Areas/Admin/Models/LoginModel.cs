using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BO_Business_Logic_Layer_.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời bạn nhập UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập Email")]
        public string Email { get; set; }
    }
}

//Formatcode(chinh dung dinh dang) :ctrl K D