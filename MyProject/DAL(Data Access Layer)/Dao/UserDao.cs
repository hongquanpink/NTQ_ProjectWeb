using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Data_Access_Layer_.EF;

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
