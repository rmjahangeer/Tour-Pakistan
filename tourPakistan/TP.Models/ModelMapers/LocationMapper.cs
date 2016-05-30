using System;
using System.Linq;
using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace TP.Models.ModelMapers
{
    public static class LocationMapper
    {
        public static LocationModel MapFromServerToClient(this Location source)
        {
            var toReturn = new LocationModel
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
            if (source.LocationImages.Count > 0)
            {
                toReturn.LocationImage = source.LocationImages.OrderBy(x=>x.RecCreatedDate).FirstOrDefault().MapFromServerToClient();
                toReturn.ImageBase64 = "data:image/png;base64," + Convert.ToBase64String(toReturn.LocationImage.ImageData);
            }
            return toReturn;
        }
        public static LocationModel MapLocationWithImages(this Location source)
        {
            var toReturn = new LocationModel
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
            if (source.LocationImages.Count > 0)
            {
                toReturn.LocationImages = source.LocationImages.Select(x => new LocationImageWebModel
                {
                    
                    ImageBase64 = "data:image/png;base64," + Convert.ToBase64String(x.ImageData),
                    ImageId = x.ImageId
                }).ToList();
            }
            return toReturn;
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


