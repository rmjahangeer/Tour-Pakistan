using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace TP.Models.ModelMapers
{
    public static class LocationImageMapper
    {
        public static LocationImageWebModel MapFromServerToClient(this LocationImage source)
        {
            return new LocationImageWebModel
            {
                ImageId = source.ImageId,
                LocationId = source.LocationId,
                ContentType = source.ContentType,
                ImageData = source.ImageData,
                IsActive = source.IsActive,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                LocationName = source.Location.LocationName,
                LocationDescription = source.Location.LocationDescription

            };
        }

        public static LocationImage MapFromClientToServer(this LocationImageWebModel source)
        {
            return new LocationImage
            {
                ImageId = source.ImageId,
                LocationId = source.LocationId,
                ContentType = source.ContentType,
                ImageData = source.ImageData,
                IsActive = source.IsActive,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}
