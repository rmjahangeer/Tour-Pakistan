using System.Collections.Generic;
using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace TP.Interfaces.IServices
{
    public interface ILocationImageService
    {
        IEnumerable<Location> GetAllLocationImages(long locationId);
        bool AddUpdateLocationImages(List<LocationImageWebModel> locationImages);

        Location GetLocationImageById(long id);
        bool DeleteLocationImage(long id);
    }
}
