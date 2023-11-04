using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace PE.Api.Controllers
{
    public class UsersController : ODataController
    {
        private readonly IUsersRepository _repository;

        public UsersController(IUsersRepository repository)
        {
            this._repository = repository;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_repository.GetUsers());
        }
        [EnableQuery]
        public IActionResult Get(int key, string version)
        {
            return Ok(_repository.GetById(key));
        }
        [EnableQuery]
        public IActionResult Post([FromBody] Users user)
        {
            _repository.Save(user);
            return Created(user);
        }
        [EnableQuery]
        public IActionResult Delete([FromRoute] int key)
        {
            _repository.Delete(key);
            return NoContent();
        }
        [EnableQuery]
        public IActionResult Put([FromBody] Users user, [FromRoute] int key)
        {
            if (key != user.User_Id)
            {
                return BadRequest();
            }
            _repository.Update(user);
            return NoContent();
        }
    }
}
