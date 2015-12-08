using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DomainModels
{
    public class Province
    {
        public Province()
        {
            this.Areas = new HashSet<Area>();
        }

        public long ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdate { get; set; }
        public string RecUpdatedBy { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}
