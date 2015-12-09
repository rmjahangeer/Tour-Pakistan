using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    public class SeasonRepository
    {
        private readonly BaseDbContext entities;

        public SeasonRepository()
        {
            entities = new BaseDbContext();
        }

        public IEnumerable<Season> GetAll()
        {
            return entities.Seasons.Select(x => x).ToList();
        }

        public Season GetById(long id)
        {
            return entities.Seasons.FirstOrDefault(x => x.SeasonId.Equals(id));
        }
    }
}
