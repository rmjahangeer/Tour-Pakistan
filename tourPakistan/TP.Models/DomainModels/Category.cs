using System.Collections.Generic;

namespace TP.Models.DomainModels
{
    public class Category
    {
        public Category()
        {
            this.Locations = new HashSet<Location>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
