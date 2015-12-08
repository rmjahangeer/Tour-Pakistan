namespace Models.DomainModels
{
    public class Season
    {
        public long SeasonId { get; set; }
        public string SeasonName { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdate { get; set; }
        public string RecUpdatedBy { get; set; }
    }
}
