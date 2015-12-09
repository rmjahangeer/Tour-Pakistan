using System.Collections.Generic;
using System.Linq;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    public class AreaRepository
    {
        private readonly BaseDbContext entities;

        public AreaRepository()
        {
            entities = new BaseDbContext();
        }

        public IEnumerable<Area> GetAll()
        {
            return entities.Areas.Select(x => x).ToList();
        }

        public Area GetById(long id)
        {
            return entities.Areas.FirstOrDefault(x => x.AreaId.Equals(id));
        }
    }
}
