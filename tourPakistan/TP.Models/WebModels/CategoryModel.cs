namespace TP.Models.WebModels
{
    public class CategoryModel
    {

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public bool IsActive { get; set; }

        
    }
}
