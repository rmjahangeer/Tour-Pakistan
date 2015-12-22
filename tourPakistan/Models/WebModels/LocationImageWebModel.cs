using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WebModels
{
    public class LocationImageWebModel
    {
        public long ImageId { get; set; }
        public string Path { get; set; }
        public long LocationId { get; set; }
        public string ImageType { get; set; }
    }
}
