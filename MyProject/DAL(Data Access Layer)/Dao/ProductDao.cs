using DAL_Data_Access_Layer_.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Data_Access_Layer_.Dao
{
    public class ProductDao
    {
        QLBanHangDbContext db = null;

        public ProductDao()
        {
            db = new QLBanHangDbContext();
        }

        public long Insert(Products products)
        {
            db.Products.Add(products);
            db.SaveChanges();
            return products.Id;
        }



        public IEnumerable<Products> ListAllPaging(string Trending, string Nottrend ,string searchString ,int page, int pageSize)
        {
            IQueryable<Products> model = db.Products;
            if (!string.IsNullOrEmpty(searchString) || !string.IsNullOrEmpty(Trending) || !string.IsNullOrEmpty(Nottrend) )
            {
                model = model.Where(x => x.ProductName.Contains(searchString));
                if(Trending != null )
                {
                    model = model.Where(x => x.Trending == true);
                }
                if (Nottrend != null)
                {
                    model = model.Where(x => x.Trending == false);
                }
                if(model== null)
                {
                    return null;
                }

                return model.OrderByDescending(x => x.NumberViews).ToPagedList(page, pageSize);
            }

            return model.OrderByDescending(x => x.NumberViews).ToPagedList(page, pageSize);
        }
        public Products getByID(int id)
        {
            var product = db.Products.Find(id);
            return product;
        }
        public Products ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
        public bool Update(Products product)
        {
            try
            {
                var products = db.Products.Find(product.Id);
                products.CategoryID = product.CategoryID;
                products.ProductName = product.ProductName;
                products.Path = product.Path;
                products.Slug = product.Slug;
                products.Detail = product.Detail;
                products.Trending = product.Trending;
                products.Status = product.Status;
                products.NumberViews = product.NumberViews;
                products.Price = product.Price;
                products.MetaKey = product.MetaKey;
                products.CreatAt = DateTime.Now;
                products.UpdateAt = DateTime.Now;
                products.DeleteAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                var products = db.Products.Find(Id);
                products.Status = false;
                products.DeleteAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
