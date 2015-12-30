using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TP.Interfaces.IRepository;
using TP.Models.DomainModels;
using TP.Repository.BaseRepository;

namespace TP.Repository.Repositories
{
    public sealed class SeasonRepository : BaseRepository<Season>, ISeasonRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SeasonRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Season> DbSet
        {
            get { return db.Seasons; }
        }

        #endregion

        public IEnumerable<Season> GetAllSeasons()
        {
            return DbSet.Select(x => x).ToList();
        }
    }
}
