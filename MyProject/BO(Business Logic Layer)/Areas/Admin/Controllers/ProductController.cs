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
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(int pages = 1, int pageSizes = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(pages, pageSizes);
            return View(model);
        }

        [HttpGet]
        public ActionResult Creat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Products product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();



               long ma = dao.Insert(product);
                if (ma > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Them san pham thanh cong");
                }
            }
            return View("Index");
        }
    }
}