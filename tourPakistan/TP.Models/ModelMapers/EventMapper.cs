using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace TP.Models.ModelMapers
{
    public static class EventMapper
    {
        public static EventModel MapFromServerToClient(this Event source)
        {
            return new EventModel
            {
                EventId = source.EventId,
                Title = source.Title,
                Description = source.Description,
                ScheduledDate = source.ScheduledDate,
                EndDate = source.EndDate,
                RegistrationStartDate = source.RegistrationStartDate,
                RegistrationEndDate = source.RegistrationEndDate,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                
                
            };
        }

        public static Event MapFromClientToServer(this EventModel source)
        {
            return new Event
            {
                EventId = source.EventId,
                Title = source.Title,
                Description = source.Description,
                ScheduledDate = source.ScheduledDate,
                EndDate = source.EndDate,
                RegistrationStartDate = source.RegistrationStartDate,
                RegistrationEndDate = source.RegistrationEndDate,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
            };
        }
    }
}
