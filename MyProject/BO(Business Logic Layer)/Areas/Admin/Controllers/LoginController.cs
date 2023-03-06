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
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            var dao = new UserDao();
            var loginResult = dao.Login(model.Password, model.Email);

            switch (loginResult)
            {
                case 1:
                    var user = dao.GetByEmail(model.Email);
                    var userSession = new UserLogin
                    {
                        UserName = user.Username,
                        Email = user.Email,
                        PassWord=user.Password,
                        Id = user.Id
                    };
                    Session[CommonConstants.USER_SESSION] = userSession;
                    if (user.Role == 1)
                    {
                        return RedirectToAction("Index", "HomeAdmin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                case 0:
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                    break;

                case -1:
                    ModelState.AddModelError("", "Tài khoản bị xoá!");
                    break;

                case -2:
                    ModelState.AddModelError("", "Mật khẩu không đúng!");
                    break;

                default:
                    ModelState.AddModelError("", "Thông tin đăng nhập không đúng!");
                    break;
            }
            return View("Index");
        }

        //public ActionResult Login(LoginModel model)
        //{
        //    if (ModelState.IsValid) //vuot qua kiem tra form rong
        //    {
        //        var dao = new UserDao();
        //        var result = dao.Login(model.UserName, model.Password, model.Email);

        //        if (result)
        //        {
        //            var user = dao.GetByID(model.UserName);

        //            var userSession = new UserLogin();
        //            userSession.UserName = user.Username;
        //            userSession.Id = user.Id;

        //            Session.Add(CommonConstants.USER_SESSION, userSession);
        //            return RedirectToAction("Index", "HomeAdmin");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Dang nhap khong dung");
        //        }
        //    }

        //        return View("Index");
        //    //switch (result)
        //    //    {
        //    //        case 1:
        //    //            var user = dao.GetByEmail(model.Email);
        //    //            var userSession = new UserLogin
        //    //            {
        //    //                UserName = user.Username,
        //    //                PassWord = user.Password,
        //    //                Email = user.Email,
        //    //                Id =user.Id,
        //    //            };
        //    //            Session[CommonConstants.USER_SESSION] = userSession;
        //    //            if (user.Role == 1)
        //    //            {
        //    //                return RedirectToAction("Index", "HomeAdmin");
        //    //            }
        //    //            else
        //    //            {
        //    //                return RedirectToAction("Index", "Home");
        //    //            }

        //    //        case 0:
        //    //            ModelState.AddModelError("", "Tài khoản không tồn tại!");
        //    //            break;

        //    //        case -1:
        //    //            ModelState.AddModelError("", "Tài khoản bị xoá!");
        //    //            break;

        //    //        case -2:
        //    //            ModelState.AddModelError("", "Mật khẩu không đúng!");
        //    //            break;

        //    //        default:
        //    //            ModelState.AddModelError("", "Thông tin đăng nhập không đúng!");
        //    //            break;
        //    //    }

    }
}
