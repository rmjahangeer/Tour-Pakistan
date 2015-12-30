using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IServices
{
    public interface ISeasonService
    {
        IEnumerable<Season> GetAllSeasons();
        bool AddUpdateSeason(Season season);

        Season GetSeasonById(int id);
    }
}
