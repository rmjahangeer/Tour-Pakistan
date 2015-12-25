using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Models.WebModels;

namespace Models.ModelMappers
{
    public static class ProvinceMapper
    {
        public static ProvinceWebModel MapFromServerToClient(this Province source)
        {
            return new ProvinceWebModel
            {
                ProvinceId = source.ProvinceId,
                ProvinceName = source.ProvinceName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdate = source.RecLastUpdate,
                RecUpdatedBy = source.RecUpdatedBy
            };
        }

        public static Province MapFromClientToServer(this ProvinceWebModel source)
        {
            return new Province
            {
                ProvinceId = source.ProvinceId,
                ProvinceName = source.ProvinceName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdate = source.RecLastUpdate,
                RecUpdatedBy = source.RecUpdatedBy
            };
        }
    }
}
