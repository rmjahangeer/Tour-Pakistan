using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Repository.Repositories;

namespace TP.Service.Service
{
    public class SeasonService
    {
        private SeasonRepository repository;
        public SeasonService()
        {
            repository = new SeasonRepository();
        }

        public List<Season> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public Season GetById(long id)
        {
            return repository.GetById(id);
        }
    }
}
