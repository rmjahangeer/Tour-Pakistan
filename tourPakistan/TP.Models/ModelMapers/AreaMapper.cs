using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace TP.Models.ModelMapers
{
    public static class AreaMapper
    {
        public static AreaModel MapFromServerToClient(this Area source)
        {
            return new AreaModel
            {
                ProvinceId = source.ProvinceId,
                AreaId = source.AreaId,
                AreaName = source.AreaName,
                AreaDescription = source.AreaDescription,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                IsActive = source.IsActive,
                ProvinceName = source.Province.ProvinceName
            };
        }

        public static Area MapFromClientToServer(this AreaModel source)
        {
            return new Area
            {
                ProvinceId = source.ProvinceId,
                AreaId = source.AreaId,
                AreaName = source.AreaName,
                AreaDescription = source.AreaDescription,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                IsActive = source.IsActive
            };
        }
    }
}
