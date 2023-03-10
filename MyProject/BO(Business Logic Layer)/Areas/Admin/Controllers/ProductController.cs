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
        public ActionResult Index(string isTrending, string notTrend, string searchString, int pages=1, int pageSize=10)
        {
            var dao = new ProductDao();
            
            var model = dao.ListAllPaging(isTrending, notTrend, searchString , pages, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Creat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Creat(Products product)
        {
            if (ModelState.IsValid)
            {
               var dao = new ProductDao();

               product.CreatAt = DateTime.Now;
               long ma = dao.Insert(product);
                if (ma > 0)
                {
                    TempData["success"] = "Them product thanh cong";
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Them san pham k thanh cong");
                }
            }
            //TempData["CreateProductMesseage"] = "Thêm sản phẩm thành công";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Products products)
        {
            if(ModelState.IsValid)
            {
                var dao = new ProductDao();
               
                var result = dao.Update(products);
                if (result)
                {
                    TempData["success"] = "Sửa product thanh cong";
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Sua san pham k thanh cong");
                }
            }
            
            return RedirectToAction("Index","Product");
        }

        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            new ProductDao().Delete(Id);
            TempData["success"] = "Xóa product thanh cong";
            return RedirectToAction("Index");
        }


    }
}