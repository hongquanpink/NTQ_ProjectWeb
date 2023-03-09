using BO_Business_Logic_Layer_.Areas.Admin.Models;
using DAL_Data_Access_Layer_.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BO_Business_Logic_Layer_.Controllers
{
    public class MyProfilesController : Controller
    {
        // GET: MyProfile
        public ActionResult Index()
        {
            var dao = new UserDao();
            var session = (BO_Business_Logic_Layer_.Common.UserLogin)Session[BO_Business_Logic_Layer_.Common.CommonConstants.USER_SESSION];
            var user = dao.GetByID(session.UserName);
            int role;
            if (user.Role == 1)
            {
                role = 1;
            }
            else
            {
                role = 0;
            }
            var result = new RegisterModel
            {
                ID = user.Id,
                Email = user.Email,
                Password = user.Password,
                Role = role,
                UserName = user.Username
            };
            return View(result);
        }
    }
}