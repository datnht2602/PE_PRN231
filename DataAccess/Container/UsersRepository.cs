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
    internal class UsersRepository : IUsersRepository
    {
        public void Delete(int id)
        => UsersDAO.Delete(id);

        public Users GetById(int id)
         => UsersDAO.FindById(id);

        public IEnumerable<Users> GetUsers()
        => UsersDAO.GetUsers();

        public void Save(Users users)
        => UsersDAO.Save(users);

        public void Update(Users users)
        => UsersDAO.Update(users);
    }
}
