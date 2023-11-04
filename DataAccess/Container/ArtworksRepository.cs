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
    internal class ArtworksRepository : IArtworksRepository
    {
        public void Delete(int id)
        => ArtworksDAO.Delete(id);

        public IEnumerable<Artworks> GetArtworks()
        => ArtworksDAO.GetArtworks();

        public Artworks GetById(int id)
        => ArtworksDAO.FindById(id);

        public void Save(Artworks artwork)
        => ArtworksDAO.Save(artwork);

        public void Update(Artworks artwork)
        => ArtworksDAO.Update(artwork);
    }
}
