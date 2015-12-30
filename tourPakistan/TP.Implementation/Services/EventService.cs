using System.Collections.Generic;
using TP.Interfaces.IRepository;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;

namespace TP.Implementation.Services
{
    public class EventService:IEventService
    {
        private readonly IEventRepository EventRepository;

        public EventService(IEventRepository EventRepository)
        {
            this.EventRepository = EventRepository;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return EventRepository.GetAllEvents();
        }

        public bool AddUpdateEvents(Event Event)
        {
            if (Event.EventId == 0)
            {
                EventRepository.Add(Event);
            }
            else
            {
                EventRepository.Update(Event);
            }
            EventRepository.SaveChanges();
            return true;
        }

        public Event GetEventById(long id)
        {
            return EventRepository.Find(id);
        }

        public bool DeleteEvent(long id)
        {
            var toDetele = EventRepository.Find(id);
            EventRepository.Delete(toDetele);
            EventRepository.SaveChanges();
            return true;

        }

    }
}
