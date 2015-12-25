using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Models.WebModels;

namespace Models.ModelMappers
{
    public static class AreaMapper
    {
        public static AreaWebModel MapFromServerToClient(this Area source)
        {
            return new AreaWebModel
            {
                ProvinceId = source.ProvinceId,
                AreaId = source.AreaId,
                AreaName = source.AreaName,
                AreaDescription = source.AreaDescription,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdate = source.RecLastUpdate,
                RecUpdatedBy = source.RecUpdatedBy
            };
        }

        public static Area MapFromClientToServer(this AreaWebModel source)
        {
            return new Area
            {
                ProvinceId = source.ProvinceId,
                AreaId = source.AreaId,
                AreaName = source.AreaName,
                AreaDescription = source.AreaDescription,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdate = source.RecLastUpdate,
                RecUpdatedBy = source.RecUpdatedBy
            };
        }
    }
}
