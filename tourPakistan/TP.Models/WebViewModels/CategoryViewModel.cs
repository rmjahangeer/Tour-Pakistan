using System.Collections.Generic;
using TP.Models.WebModels;

namespace TP.Models.WebViewModels
{
    public class CategoryViewModel
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<LocationModel> Locations { get; set; }
    }
}
