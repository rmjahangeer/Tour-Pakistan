using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Models.WebModels;

namespace Models.ModelMappers
{
    public static class LocationImageMapper
    {
        public static LocationImageWebModel MapFromServerToClient(this LocationImage source)
        {
            return new LocationImageWebModel
            {
                ImageId = source.ImageId,
                Path = source.Path,
                LocationId = source.LocationId,
                ImageType = source.ImageType
                
            };
        }

        public static LocationImage MapFromClientToServer(this LocationImageWebModel source)
        {
            return new LocationImage
            {
                ImageId = source.ImageId,
                Path = source.Path,
                LocationId = source.LocationId,
                ImageType = source.ImageType
            };
        }
    }
}
