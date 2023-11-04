using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IArtworksRepository
    {
        void Save(Artworks artwork);
        Artworks GetById(int id);

        void Delete(int id);
        void Update(Artworks artwork);
        IEnumerable<Artworks> GetArtworks();
    }
}
