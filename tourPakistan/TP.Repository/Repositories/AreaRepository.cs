using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TP.Interfaces.IRepository;
using TP.Models.DomainModels;
using TP.Repository.BaseRepository;

namespace TP.Repository.Repositories
{
    public sealed class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AreaRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Area> DbSet
        {
            get { return db.Areas; }
        }
        #endregion

        public IEnumerable<Area> GetAllAreas()
        {
            return DbSet.Select(x=>x).ToList();
        }

        public IEnumerable<Area> GetAllActiveAreas()
        {
            return DbSet.Where(x => x.IsActive == true).ToList();
        }
    }
}
