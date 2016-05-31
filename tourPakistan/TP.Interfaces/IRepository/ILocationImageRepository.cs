using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IRepository
{
    public interface ILocationImageRepository : IBaseRepository<LocationImage, long>
    {
        IEnumerable<LocationImage> GetAllLocationImages(long locationId);
        bool DeleteAllLocationImages(long locationId);
    }
}
