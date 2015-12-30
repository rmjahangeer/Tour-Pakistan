using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IRepository
{
    public interface IEventRepository : IBaseRepository<Event, long>
    {
        IEnumerable<Event> GetAllEvents();
    }
}
