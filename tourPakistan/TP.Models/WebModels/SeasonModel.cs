using System;

namespace TP.Models.WebModels
{
    public class SeasonModel
    {
        public long SeasonId { get; set; }
        public string SeasonName { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
    }
}
