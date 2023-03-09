using DAL_Data_Access_Layer_.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return entity.Id;
        }

        public User GetByID(string userName)
        {
            return db.User.SingleOrDefault(x => x.Username == userName);
        }

        public User GetByEmail(string email)
        {
            return db.User.SingleOrDefault(x => x.Email == email);
        }
        public int Login(string passWord, string email)
        {
            var result = db.User.SingleOrDefault(x => x.Email == email);
            if (result == null)
            {
                return 0;//tai khoan khong ton tai
            }
            if (result.Status == false)
            {
                return -1;//tai khoan da bi xoa
            }
            if (result.Password != passWord)
            {
                return -2;//mat khau sai
            }

            return 1;
        }

        //Ham dung de phan trang,fiter
        public IEnumerable<User> ListAllPaging(string active, string inActive, string admin, string user, string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.User;
            if (!string.IsNullOrEmpty(searchString) || !string.IsNullOrEmpty(active) || !string.IsNullOrEmpty(inActive) || !string.IsNullOrEmpty(admin) || !string.IsNullOrEmpty(user))
            {
                model = model.Where(x => x.Username.Contains(searchString));
                if (active != null)
                {
                    model = model.Where(x => x.Status == true);
                }
                if (inActive != null)
                {
                    model = model.Where(x => x.Status == false);
                }
                if (admin != null)
                {
                    model = model.Where(x => x.Role == 1);
                }
                if (user != null)
                {
                    model = model.Where(x => x.Role == 0);
                }
                if (model == null)
                {
                    return null;
                }
                return model.OrderByDescending(x => x.CreatAt).ToPagedList(page, pageSize);
            }
            return model.OrderByDescending(x => x.CreatAt).ToPagedList(page, pageSize);
        }

        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }

        public bool CheckUserName(string userName)
        {
            var name = db.User.SingleOrDefault(x => x.Username == userName);
            if (name == null) return true;
            return false;
        }
        public bool CheckEmail(string email)
        {
            var name = db.User.SingleOrDefault(x => x.Email == email);
            if (name == null) return true;
            return false;
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

        public bool Delete(int id)
        {
            try
            {
                var user = db.User.Find(id);
                user.Status = false;
                user.DeleteAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

    }
}
