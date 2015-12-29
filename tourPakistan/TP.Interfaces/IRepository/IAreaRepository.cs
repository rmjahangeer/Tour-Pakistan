using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IRepository
{
    public interface IAreaRepository : IBaseRepository<Area, long>
    {
        IEnumerable<Area> GetAllAreas();
        IEnumerable<Area> GetAllActiveAreas();
    }
}
