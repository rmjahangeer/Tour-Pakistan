using System.Collections.Generic;
using TP.Interfaces.IRepository;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;
using TP.Models.ModelMapers;
using TP.Models.WebModels;

namespace TP.Implementation.Services
{
    public class LocationImageService:ILocationImageService
    {
        private readonly ILocationImageRepository locationImageRepository;

        public LocationImageService(ILocationImageRepository locationImageRepository)
        {
            this.locationImageRepository = locationImageRepository;
        }


        public IEnumerable<Location> GetAllLocationImages(long locationId)
        {
            throw new System.NotImplementedException();
        }

        public bool AddUpdateLocationImages(List<LocationImageWebModel> locationImages)
        {
            foreach (var locationImage in locationImages)
            {
                locationImageRepository.Add(locationImage.MapFromClientToServer());
            }
            return true;
        }

        public Location GetLocationImageById(long id)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteLocationImage(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
