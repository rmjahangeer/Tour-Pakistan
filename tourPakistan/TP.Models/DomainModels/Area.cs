﻿using System.Collections.Generic;

namespace Models.DomainModels
{
    public class Area
    {
        public Area()
        {
            this.Locations = new HashSet<Location>();
        }

        public long AreaId { get; set; }
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public long ProvinceId { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdate { get; set; }
        public string RecUpdatedBy { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}