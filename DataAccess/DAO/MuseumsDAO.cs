using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MuseumsDAO
    {
        public static List<Museums> GetMuseums()
        {
            var listMuseums = new List<Museums>();
            try
            {
                using (var context = new AppDBContext())
                {
                    listMuseums = context.Museums.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listMuseums;
        }
        public static Museums FindById(int id)
        {
            Museums p = new Museums();
            try
            {
                using (var context = new AppDBContext())
                {
                    p = context.Museums.SingleOrDefault(x => x.Museum_Id == id)!;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }
        public static void Save(Museums p)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Museums.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Update(Museums p)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Entry<Museums>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    var p1 = context.Museums.SingleOrDefault(c => c.Museum_Id == p);
                    context.Museums.Remove(p1);
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
