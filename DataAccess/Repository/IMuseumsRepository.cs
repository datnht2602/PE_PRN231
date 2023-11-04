using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMuseumsRepository
    {
        void Save(Museums museums);
        Museums GetById(int id);

        void Delete(int id);
        void Update(Museums museums);
        IEnumerable<Museums> GetMuseums();
    }
}
