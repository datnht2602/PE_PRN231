using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace PE.Api.Controllers
{
    public class MuseumsController : ODataController
    {
        private readonly IMuseumsRepository _repository;

        public MuseumsController(IMuseumsRepository repository)
        {
            this._repository = repository;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_repository.GetMuseums());
        }
        [EnableQuery]
        public IActionResult Get(int key, string version)
        {
            return Ok(_repository.GetById(key));
        }
        [EnableQuery]
        public IActionResult Post([FromBody] Museums meseum)
        {
            _repository.Save(meseum);
            return Created(meseum);
        }
        [EnableQuery]
        public IActionResult Delete([FromRoute] int key)
        {
            _repository.Delete(key);
            return NoContent();
        }
        [EnableQuery]
        public IActionResult Put([FromBody] Museums museum, [FromRoute] int key)
        {
            if (key != museum.Museum_Id)
            {
                return BadRequest();
            }
            _repository.Update(museum);
            return NoContent();
        }
    }
}
