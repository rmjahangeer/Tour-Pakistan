using System.Collections.Generic;
using System.Linq;
using TP.Interfaces.IRepository;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;

namespace TP.Implementation.Services
{
    public class ProvinceService:IProvinceService
    {
        private readonly IProvinceRepository provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            this.provinceRepository = provinceRepository;
        }

        public IEnumerable<Province> GetAllProvinces()
        {
            return provinceRepository.GetAll().ToList();
        }

        public bool AddUpdateProvince(Province province)
        {
            if (province.ProvinceId == 0)
            {
                provinceRepository.Add(province);
            }
            else
            {
                provinceRepository.Update(province);
            }
            provinceRepository.SaveChanges();
            return true;
        }

        public Province GetProvinceById(int id)
        {
            return provinceRepository.Find(id);
        }
    }
}
