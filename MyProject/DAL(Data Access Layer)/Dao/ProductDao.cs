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
    }
}
