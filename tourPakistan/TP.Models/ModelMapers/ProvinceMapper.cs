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
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                AddedBy = source.AspNetUser.FirstName + " " + source.AspNetUser.LastName,
                AddedDate = source.RecCreatedDate.ToString("dd-MMM-yyyy")
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
