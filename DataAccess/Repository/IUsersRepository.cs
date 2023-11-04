using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IUsersRepository
    {
        void Save(Users users);
        Users GetById(int id);

        void Delete(int id);
        void Update(Users users);
        IEnumerable<Users> GetUsers();
    }
}
