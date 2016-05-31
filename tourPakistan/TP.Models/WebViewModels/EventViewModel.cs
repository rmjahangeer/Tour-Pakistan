using System.Collections.Generic;
using TP.Models.WebModels;

namespace TP.Models.WebViewModels
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            Event = new EventModel();
            Locations = new List<LocationModel>();
        }
        public EventModel Event { get; set; }
        public IEnumerable<LocationModel> Locations { get; set; }
    }
}
