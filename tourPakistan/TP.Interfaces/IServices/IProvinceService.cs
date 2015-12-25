using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IServices
{
    public interface IProvinceService
    {
        IEnumerable<Province> GetAllProvinces();
        bool AddUpdateProvince(Province province);

        Province GetProvinceById(int id);
    }
}
