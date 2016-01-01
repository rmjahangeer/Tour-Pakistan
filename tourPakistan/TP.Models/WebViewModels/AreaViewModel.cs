using System.Collections.Generic;
using TP.Models.WebModels;

namespace TP.Models.WebViewModels
{
    public class AreaViewModel
    {
        public AreaViewModel()
        {
            ProvinceDdl = new List<ProvinceModel>();
            Area = new AreaModel();
        }
        public List<ProvinceModel> ProvinceDdl { get; set; }
        public AreaModel Area { get; set; }
    }
}
