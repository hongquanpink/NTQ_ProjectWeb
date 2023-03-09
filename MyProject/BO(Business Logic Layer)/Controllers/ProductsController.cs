using DAL_Data_Access_Layer_.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BO_Business_Logic_Layer_.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Product
        public ActionResult Index(string Trending,string Nottrend,string seachString,int page=1,int pagesize=10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(Trending,Nottrend, seachString, page, pagesize);
          

            return View(model);
        }
    }
}