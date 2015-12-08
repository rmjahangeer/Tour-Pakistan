using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Models.WebModels;

namespace Models.ModelMappers
{
    public static class SeasonMapper
    {
        public static SeasonWebModel MapFromServerToClient(this Season source)
        {
            return new SeasonWebModel
            {
                SeasonId = source.SeasonId,
                SeasonName = source.SeasonName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdate = source.RecLastUpdate,
                RecUpdatedBy = source.RecUpdatedBy
            };
        }

        public static Season MapFromClientToServer(this SeasonWebModel source)
        {
            return new Season
            {
                SeasonId = source.SeasonId,
                SeasonName = source.SeasonName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdate = source.RecLastUpdate,
                RecUpdatedBy = source.RecUpdatedBy
            };
        }
    }
}
