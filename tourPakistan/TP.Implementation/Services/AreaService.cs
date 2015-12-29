using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TP.Interfaces.IRepository;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;

namespace TP.Implementation.Services
{
    public class AreaService:IAreaService
    {
        private readonly IAreaRepository AreaRepository;

        public AreaService(IAreaRepository AreaRepository)
        {
            this.AreaRepository = AreaRepository;
        }

        public IEnumerable<Area> GetAllAreas()
        {
            return AreaRepository.GetAllAreas();
        }

        public bool AddUpdateArea(Area area)
        {
            if (area.AreaId == 0)
            {
                AreaRepository.Add(area);
            }
            else
            {
                AreaRepository.Update(area);
            }
            AreaRepository.SaveChanges();
            return true;
        }

        public Area GetAreaById(long id)
        {
            return AreaRepository.Find(id);
        }

        public bool DeleteArea(long id)
        {
            var toDetele = AreaRepository.Find(id);
            AreaRepository.Delete(toDetele);
            AreaRepository.SaveChanges();
            return true;

        }

    }
}
