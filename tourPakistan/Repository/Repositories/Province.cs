using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    public class ProvinceRepository
    {
        private readonly BaseDbContext entities;

        private ProvinceRepository()
        {
            entities = new BaseDbContext();
        }

        private IEnumerable<Province> GetAll()
        {
            return entities.Provinces.Select(x => x).ToList();
        }

        private Province GetById(long id)
        {
            return entities.Provinces.FirstOrDefault(x => x.ProvinceId.Equals(id));
        }
    }
}
