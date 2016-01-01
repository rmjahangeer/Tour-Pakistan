using System.Collections.Generic;
using TP.Interfaces.IRepository;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;

namespace TP.Implementation.Services
{
    public class LocationService:ILocationService
    {
        private readonly ILocationRepository LocationRepository;

        public LocationService(ILocationRepository LocationRepository)
        {
            this.LocationRepository = LocationRepository;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return LocationRepository.GetAllLocations();
        }

        public bool AddUpdateLocations(Location Location)
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
            return true;
        }

        public Location GetLocationById(long id)
        {
            return LocationRepository.Find(id);
        }

        public bool DeleteLocation(long id)
        {
            var toDetele = LocationRepository.Find(id);
            LocationRepository.Delete(toDetele);
            LocationRepository.SaveChanges();
            return true;

        }

    }
}
