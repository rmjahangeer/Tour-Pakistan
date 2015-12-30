using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace TP.Models.ModelMapers
{
    public static class SeasonMapper
    {
        public static SeasonModel MapFromServerToClient(this Season source)
        {
            return new SeasonModel
            {
                SeasonId = source.SeasonId,
                SeasonName = source.SeasonName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
                
            };
        }

        public static Season MapFromClientToServer(this SeasonModel source)
        {
            return new Season
            {
                SeasonId = source.SeasonId,
                SeasonName = source.SeasonName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}
