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
            return entity.Id;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.Id);
                user.Username = entity.Username;
                user.Role = entity.Role;
                user.Email = entity.Email;
                user.CreatAt = DateTime.Now;
                user.UpdateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                //logging code 
                return false;
            }
        }
        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }


        //Ham dung de phan trang
        public IEnumerable<User> ListAllPaging(int page , int pageSize )
        {
            return db.User.OrderByDescending(x => x.CreatAt).ToPagedList(page,pageSize);
        }

        public User GetByID(string userName)
        {
            return db.User.SingleOrDefault(x=>x.Username == userName);
        }
        public bool Login (string userName,string passWord,string email)
        {
            var result = db.User.Count(x => x.Email == email && x.Username == userName && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
