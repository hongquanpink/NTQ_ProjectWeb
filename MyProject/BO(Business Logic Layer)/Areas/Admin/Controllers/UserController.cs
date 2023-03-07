using BO_Business_Logic_Layer_.Common;
using DAL_Data_Access_Layer_.Dao;
using DAL_Data_Access_Layer_.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BO_Business_Logic_Layer_.Areas.Admin.Controllers
{
    public class UserController :Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page=1  , int pageSize=10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(page,pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Creat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var encrytedMd5Pas = Encryptor.Hash(user.Password);
                user.Password = encrytedMd5Pas;

                user.CreatAt = DateTime.Now;
                long ma = dao.Insert(user);
                if (ma > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("","Them user thanh cong");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);

            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                //if (!string.IsNullOrEmpty(user.Password))
                //{
                //    var encrytedMd5Pas = Encryptor.Hash(user.Password);
                //    user.Password = encrytedMd5Pas;
                //}
                user.UpdateAt = DateTime.Now;
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Sua user thanh cong");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int Id)
        {        
            new UserDao().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}