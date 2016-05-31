using System.Collections.Generic;
using TP.Interfaces.IRepository;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;

namespace TP.Implementation.Services
{
    public class LocationService:ILocationService
    {
        private readonly ILocationRepository LocationRepository;
        private readonly ILocationImageRepository locationImageRepository;

        public LocationService(ILocationRepository LocationRepository, ILocationImageRepository locationImageRepository)
        {
            this.LocationRepository = LocationRepository;
            this.locationImageRepository = locationImageRepository;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return LocationRepository.GetAllLocations();
        }

        public long AddUpdateLocations(Location Location)
        {
            if (Location.LocationId == 0)
            {
                LocationRepository.Add(Location);
            }
            else
            {
                LocationRepository.Update(Location);
            }
            LocationRepository.SaveChanges();
            return Location.LocationId;
        }

        public Location GetLocationById(long id)
        {
            return LocationRepository.Find(id);
        }

        public Location GetLocationByIdWithImages(long id)
        {
            return LocationRepository.GetLocationByIdWithImages(id);
        }

        public bool DeleteLocation(long id)
        {
            var toDetele = LocationRepository.Find(id);
            locationImageRepository.DeleteAllLocationImages(toDetele.LocationId);
            LocationRepository.Delete(toDetele);
            LocationRepository.SaveChanges();
            return true;
        }

        public bool ActivateLocation(long id)
        {
            var toToggle = LocationRepository.Find(id);
            var status = false;
            if (toToggle.IsActive)
            {
                toToggle.IsActive = !toToggle.IsActive;
            }
            else
            {
                toToggle.IsActive = !toToggle.IsActive;
                status = true;
            }
            LocationRepository.SaveChanges();
            return status;
        }
    }
}
