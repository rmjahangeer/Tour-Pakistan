using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace TP.Models.ModelMapers
{
    public static class ProvinceMapper
    {
        public static ProvinceModel MapFromServerToClient(this Province source)
        {
            return new ProvinceModel
            {
                ProvinceId = source.ProvinceId,
                ProvinceName = source.ProvinceName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static Province MapFromClientToServer(this ProvinceModel source)
        {
            return new Province
            {
                ProvinceId = source.ProvinceId,
                ProvinceName = source.ProvinceName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}
