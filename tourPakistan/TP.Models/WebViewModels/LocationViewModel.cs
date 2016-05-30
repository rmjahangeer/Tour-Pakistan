using System.Collections.Generic;
using TP.Models.WebModels;

namespace TP.Models.WebViewModels
{
    public class LocationViewModel
    {
        public LocationViewModel()
        {
            ProvinceDdl = new List<ProvinceModel>();
            AreaDdl = new List<AreaModel>();
            CategoryDdl = new List<CategoryModel>();
            Location = new LocationModel();
        }
        public List<ProvinceModel> ProvinceDdl { get; set; }
        public List<AreaModel> AreaDdl { get; set; }
        public List<CategoryModel> CategoryDdl { get; set; }

        public LocationModel Location { get; set; }
    }

    public class HomeViewModel
    {
        public IEnumerable<LocationModel> Locations { get; set; }
    }
}
