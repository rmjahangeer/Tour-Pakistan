using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class LocationImage
    {
        public long ImageId { get; set; }
        public string Path { get; set; }
        public long LocationId { get; set; }
        public string ImageType { get; set; }
    }
}
