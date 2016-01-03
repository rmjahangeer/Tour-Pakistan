using System.Collections.Generic;
using System.Linq;
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


        public IEnumerable<LocationImage> GetAllLocationImages(long locationId)
        {
            return locationImageRepository.GetAllLocationImages(locationId).ToList();
        }

        public bool AddUpdateLocationImages(List<LocationImageWebModel> locationImages)
        {
            foreach (var locationImage in locationImages)
            {
                locationImageRepository.Add(locationImage.MapFromClientToServer());
            }
            locationImageRepository.SaveChanges();
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
