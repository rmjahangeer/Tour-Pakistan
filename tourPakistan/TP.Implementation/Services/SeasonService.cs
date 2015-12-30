using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TP.Interfaces.IRepository;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;

namespace TP.Implementation.Services
{
    public class SeasonService:ISeasonService
    {
        private readonly ISeasonRepository SeasonRepository;

        public SeasonService(ISeasonRepository SeasonRepository)
        {
            this.SeasonRepository = SeasonRepository;
        }

        public IEnumerable<Season> GetAllSeasons()
        {
            return SeasonRepository.GetAll().ToList();
        }

        public bool AddUpdateSeason(Season season)
        {
            if (season.SeasonId == 0)
            {
                SeasonRepository.Add(season);
            }
            else
            {
                SeasonRepository.Update(season);
            }
            SeasonRepository.SaveChanges();
            return true;
        }

        public Season GetSeasonById(int id)
        {
            return SeasonRepository.Find(id);
        }
    }
}
