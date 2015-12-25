using System.Data.Entity;
using Microsoft.Practices.Unity;
using TP.Models.DomainModels;

namespace TP.Repository.BaseRepository
{
    /// <summary>
    /// Base Db Context. Implements Identity Db Context over Application User
    /// </summary>
    public sealed class BaseDbContext : DbContext
    {
        #region Private
        private IUnityContainer container;
        #endregion
        #region Constructor
        public BaseDbContext()
        {            
        }
        #endregion
        #region Public

        public BaseDbContext(string connectionString,IUnityContainer container)
            : base(connectionString)
        {
            this.container = container;
        }
        
        #endregion
        
        /// <summary>
        /// Users
        /// </summary>
        public DbSet<AspNetUser> Users { get; set; }

        /// <summary>
        /// User Roles
        /// </summary>
        public DbSet<AspNetRole> UserRoles { get; set; }
        public DbSet<AspNetUserClaim> UserClaims { get; set; }
        public DbSet<AspNetUserLogin> UserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
    }
}
