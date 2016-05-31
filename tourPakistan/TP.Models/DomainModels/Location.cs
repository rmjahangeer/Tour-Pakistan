using System.Collections.Generic;

namespace TP.Models.DomainModels
{
    public class Location
    {
        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public int AreaId { get; set; }
        public int ProvinceId { get; set; }
        public long CategoryId { get; set; }
        public bool IsActive { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }

        public virtual Area Area { get; set; }
        public virtual Category Category { get; set; }
        public virtual Province Province { get; set; }
        public virtual ICollection<LocationImage> LocationImages { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
