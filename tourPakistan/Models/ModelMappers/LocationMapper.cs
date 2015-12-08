using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Models.WebModels;

namespace Models.ModelMappers
{
    public static class LocationMapper
    {
        public static LocationWebModel MapFromServerToClient(this Location source)
        {
            return new LocationWebModel
            {
                AreaId = source.AreaId,
                LocationId = source.LocationId,
                LocationName = source.LocationName,
                LocationDescription = source.LocationDescription,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdate = source.RecLastUpdate,
                RecUpdatedBy = source.RecUpdatedBy
            };
        }

        public static Location MapFromClientToServer(this LocationWebModel source)
        {
            return new Location
            {
                AreaId = source.AreaId,
                LocationId = source.LocationId,
                LocationName = source.LocationName,
                LocationDescription = source.LocationDescription,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdate = source.RecLastUpdate,
                RecUpdatedBy = source.RecUpdatedBy
            };
        }
    }
}


