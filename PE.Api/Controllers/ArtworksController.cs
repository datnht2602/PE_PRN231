using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace PE.Api.Controllers
{
    public class ArtworksController : ODataController
    {
        private readonly IArtworksRepository _repository;

        public ArtworksController(IArtworksRepository repository)
        {
            this._repository = repository;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_repository.GetArtworks());
        }
        [EnableQuery]
        public IActionResult Get(int key, string version)
        {
            return Ok(_repository.GetById(key));
        }
        [EnableQuery]
        public IActionResult Post([FromBody] Artworks artworks)
        {
            _repository.Save(artworks);
            return Created(artworks);
        }
        [EnableQuery]
        public IActionResult Delete([FromRoute] int key)
        {
            _repository.Delete(key);
            return NoContent();
        }
        [EnableQuery]
        public IActionResult Put([FromBody] Artworks artworks, [FromRoute] int key)
        {
            if (key != artworks.Artwork_Id)
            {
                return BadRequest();
            }
            _repository.Update(artworks);
            return NoContent();
        }
    }
}
