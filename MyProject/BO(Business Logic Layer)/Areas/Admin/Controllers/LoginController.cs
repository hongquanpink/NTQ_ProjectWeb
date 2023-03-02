using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO_Business_Logic_Layer_.Areas.Admin.Models;
using BO_Business_Logic_Layer_.Common;
using DAL_Data_Access_Layer_.Dao;



namespace BO_Business_Logic_Layer_.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid) //vuot qua kiem tra form rong
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName,Encryptor.Hash(model.Password),model.Email);
                if (result)
                {
                    var user = dao.GetByID(model.UserName);

                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.Id = user.Id;

                    Session.Add(CommonConstants.USER_SESSION,userSession);
                    return RedirectToAction("Index","HomeAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "Dang nhap khong dung");
                }
            }

            return View("Index");
           
        }
    }
}