using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IRepository
{
    public interface ISeasonRepository : IBaseRepository<Season,int>
    {
        IEnumerable<Season> GetAllSeasons();
    }
}
