using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IServices
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();
        bool AddUpdateEvents(Event events);

        Event GetEventById(long id);
        bool DeleteEvent(long id);
    }
}
