using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TP.Interfaces.IRepository;
using TP.Models.DomainModels;
using TP.Repository.BaseRepository;

namespace TP.Repository.Repositories
{
    public sealed class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CategoryRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Category> DbSet
        {
            get { return db.Categories; }
        }
        #endregion

        public IEnumerable<Category> GetAllCategories()
        {
            return DbSet.Select(x=>x).ToList();
        }

        public IEnumerable<Category> GetAllActiveCategories()
        {
            return DbSet.Where(x => x.IsActive == true).ToList();
        }
    }
}
