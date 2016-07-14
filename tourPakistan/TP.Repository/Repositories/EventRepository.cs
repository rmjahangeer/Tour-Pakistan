using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TP.Interfaces.IRepository;
using TP.Models.DomainModels;
using TP.Repository.BaseRepository;

namespace TP.Repository.Repositories
{
    public sealed class EventRepository : BaseRepository<Event>, IEventRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EventRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Event> DbSet
        {
            get { return db.Events; }
        }
        #endregion

        public IEnumerable<Event> GetAllEvents()
        {
            return DbSet.Include(x=>x.AspNetUser).Select(x=>x);
        }

    }
}
