using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IServices
{
    public interface IAreaService
    {
        IEnumerable<Area> GetAllAreas();
        bool AddUpdateArea(Area Area);

        Area GetAreaById(long id);
        bool DeleteArea(long id);
    }
}
