using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UsersDAO
    {
        public static List<Users> GetUsers()
        {
            var listUsers = new List<Users>();
            try
            {
                using (var context = new AppDBContext())
                {
                    listUsers = context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUsers;
        }
        public static Users FindById(int id)
        {
            Users p = new Users();
            try
            {
                using (var context = new AppDBContext())
                {
                    p = context.Users.SingleOrDefault(x => x.User_Id == id)!;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }
        public static void Save(Users p)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Users.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Update(Users p)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Entry<Users>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Delete(int p)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var p1 = context.Users.SingleOrDefault(c => c.User_Id == p);
                    context.Users.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
