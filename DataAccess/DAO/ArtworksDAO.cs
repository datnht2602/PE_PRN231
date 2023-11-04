using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ArtworksDAO
    {
        public static List<Artworks> GetArtworks()
        {
            var listArtworks = new List<Artworks>();
            try
            {
                using (var context = new AppDBContext())
                {
                    listArtworks = context.Artworks.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listArtworks;
        }
        public static Artworks FindById(int id)
        {
            Artworks p = new Artworks();
            try
            {
                using (var context = new AppDBContext())
                {
                    p = context.Artworks.SingleOrDefault(x => x.Artwork_Id == id)!;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }
        public static void Save(Artworks p)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Artworks.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Update(Artworks p)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Entry<Artworks>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    var p1 = context.Artworks.SingleOrDefault(c => c.Artwork_Id == p);
                    context.Artworks.Remove(p1);
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
