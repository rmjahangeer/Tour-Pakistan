using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;

namespace Models.WebModels
{
    public class ProvinceWebModel
    {

        public long ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdate { get; set; }
        public string RecUpdatedBy { get; set; }

    }
}
