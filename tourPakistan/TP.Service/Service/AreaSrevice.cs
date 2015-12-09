using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Repository.Repositories;

namespace TP.Service.Service
{
    public class AreaService
    {
        private AreaRepository repository;
        public AreaService()
        {
            repository = new AreaRepository();
        }

        public List<Area> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public Area GetById(long id)
        {
            return repository.GetById(id);
        }
    }
}
