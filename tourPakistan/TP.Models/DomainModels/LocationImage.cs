namespace TP.Models.DomainModels
{
    public class LocationImage
    {
        public long ImageId { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public long LocationId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual Location Location { get; set; }
    }
}
