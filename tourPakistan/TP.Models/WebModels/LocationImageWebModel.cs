using System;
using System.Collections.Generic;
using System.Web;

namespace TP.Models.WebModels
{
    public class LocationImageWebModel
    {
        public long ImageId { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public string ImageBase64 { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public long LocationId { get; set; }
        public bool IsActive { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}
