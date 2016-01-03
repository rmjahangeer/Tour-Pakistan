using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IServices
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAllLocations();
        long AddUpdateLocations(Location locations);

        Location GetLocationById(long id);
        bool DeleteLocation(long id);
    }
}
