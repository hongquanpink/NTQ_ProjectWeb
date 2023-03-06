using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Data_Access_Layer_.EF;
using PagedList;

namespace DAL_Data_Access_Layer_.Dao
{
    public class UserDao //CHU Y DE PUBLIC
    {
        QLBanHangDbContext db = null;
        public UserDao()
        {
            db = new QLBanHangDbContext();
        }

        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.Id ;
        }

        public User GetByID(string userName)
        {
            return db.User.SingleOrDefault(x => x.Username == userName);
        }

        public User GetByEmail(string email)
        {
            return db.User.SingleOrDefault( x => x.Email == email);
        }
        public int Login(string passWord, string email)
        {
            var result = db.User.SingleOrDefault(x => x.Email ==email);
            if (result == null )
            {
                return 0;//tai khoan khong ton tai
            }
            if(result.Status == false )
            {
                return -1;//tai khoan da bi xoa
            }
            if(result.Password != passWord )
            {
                return -2;//mat khau sai
            }

            return 1;
        }

        //Ham dung de phan trang
        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            return db.User.OrderByDescending(x => x.CreatAt).ToPagedList(page, pageSize);
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.Id);
            user.Username = entity.Username;
            if (!string.IsNullOrEmpty(entity.Password))
            {
                user.Password = entity.Password;
            }
            user.Role = entity.Role;
            user.Email = entity.Email;
            user.CreatAt = DateTime.Now;
            user.UpdateAt = DateTime.Now;
            db.SaveChanges();
            return true;
            }

            catch (Exception)
            {
                //logging code 
                return false;
            }
    }
        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }


        public bool Delete(int id)
    {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ) { return false; }
        }

}
}
