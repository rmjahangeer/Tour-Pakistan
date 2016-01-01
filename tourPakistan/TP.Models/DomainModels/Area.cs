using System.Collections;
using System.Collections.Generic;

namespace TP.Models.DomainModels
{
    public class Area
    {
        public Area()
        {
            this.Locations = new HashSet<Location>();
        }

        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ProvinceId { get; set; }
        public string AreaDescription { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
        public virtual Province Province { get; set; }
    }
}
