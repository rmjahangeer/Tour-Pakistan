using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TP.Interfaces.IRepository;
using TP.Models.DomainModels;
using TP.Repository.BaseRepository;

namespace TP.Repository.Repositories
{
    public sealed class LocationImageRepository : BaseRepository<LocationImage>, ILocationImageRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public LocationImageRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<LocationImage> DbSet
        {
            get { return db.LocationImages; }
        }
        #endregion

        public IEnumerable<LocationImage> GetAllLocationImages(long locationId)
        {
            return DbSet.Where(x => x.LocationId == locationId).ToList();

        }

    }
}
