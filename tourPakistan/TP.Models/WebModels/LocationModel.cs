using System.Collections;
using System.Collections.Generic;

namespace TP.Models.WebModels
{
    public class LocationModel
    {

        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }

        public IEnumerable<LocationImageWebModel> LocationImages { get; set; }
        public LocationImageWebModel LocationImage { get; set; }

        
    }
}
