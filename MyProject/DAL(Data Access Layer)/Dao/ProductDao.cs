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

        public long Insert(Products entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public IEnumerable<Products> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Products> model = db.Products;
            return model.OrderByDescending(x => x.CreatAt).ToPagedList(page, pageSize);
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
        public bool Update(Products entity)
        {
            try
            {
                var products = db.Products.Find(entity.Id);
                products.CategoryID = entity.CategoryID;
                products.Slug = entity.Slug;
                products.Detail = entity.Detail;
                products.Trending = entity.Trending;
                products.Status = entity.Status;
                products.NumberViews = entity.NumberViews;
                products.Price = entity.Price;
                products.MetaKey = entity.MetaKey;
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
