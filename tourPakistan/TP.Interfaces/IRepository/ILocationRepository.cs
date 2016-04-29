using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IRepository
{
    public interface ILocationRepository : IBaseRepository<Location, long>
    {
        IEnumerable<Location> GetAllLocations();
        IEnumerable<Location> GetAllActiveLocations();
    }
}
