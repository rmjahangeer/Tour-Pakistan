using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace Models.ModelMappers
{
    public static class LocationMapper
    {
        public static LocationModel MapFromServerToClient(this Location source)
        {
            return new LocationModel
            {
                AreaId = source.AreaId,
                AreaName = source.Area.AreaName,
                ProvinceId = source.ProvinceId,
                ProvinceName = source.Province.ProvinceName,
                CategoryId = source.CategoryId,
                CategoryName = source.Category.CategoryName,
                LocationId = source.LocationId,
                LocationName = source.LocationName,
                LocationDescription = source.LocationDescription,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                IsActive = source.IsActive
            };
        }

        public static Location MapFromClientToServer(this LocationModel source)
        {
            return new Location
            {
                AreaId = source.AreaId,
                ProvinceId = source.ProvinceId,
                CategoryId = source.CategoryId,
                LocationId = source.LocationId,
                LocationName = source.LocationName,
                LocationDescription = source.LocationDescription,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                IsActive = source.IsActive
            };
        }
    }
}


