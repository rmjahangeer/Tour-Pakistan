namespace TP.Models.DomainModels
{
    public class Season
    {
        public long SeasonId { get; set; }
        public string SeasonName { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
    }
}
