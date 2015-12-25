namespace Models.DomainModels
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdate { get; set; }
        public string RecUpdatedBy { get; set; }
    }
}
