namespace Models.WebModels
{
    public class LocationWebModel
    {
        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public long AreaId { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdate { get; set; }
        public string RecUpdatedBy { get; set; }

    }
}
