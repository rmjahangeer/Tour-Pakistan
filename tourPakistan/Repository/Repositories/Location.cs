using System.Collections.Generic;
using System.Linq;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    public class LocationRepository
    {
        private readonly BaseDbContext entities;

        public LocationRepository()
        {
            entities = new BaseDbContext();
        }

        public IEnumerable<Location> GetAll()
        {
            return entities.Locations.Select(x=>x).ToList();
        }

        public Location GetById(long id)
        {
            return entities.Locations.FirstOrDefault(x => x.LocationId.Equals(id));
        }
    }
}
