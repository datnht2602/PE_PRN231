using BusinessObject;
using DataAccess.DAO;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Container
{
    internal class MuseumsRepository : IMuseumsRepository
    {
        public void Delete(int id)
        => MuseumsDAO.Delete(id);

        public Museums GetById(int id)
        => MuseumsDAO.FindById(id);

        public IEnumerable<Museums> GetMuseums()
       => MuseumsDAO.GetMuseums();

        public void Save(Museums museums)
        => MuseumsDAO.Save(museums);

        public void Update(Museums museums)
        => MuseumsDAO.Update(museums);
    }
}
