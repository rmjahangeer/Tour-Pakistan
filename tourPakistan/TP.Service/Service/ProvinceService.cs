using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Repository.Repositories;

namespace TP.Service.Service
{
    public class ProvinceService
    {
        private SeasonRepository repository;
        public ProvinceService()
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
