using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Models.DomainModels;

namespace Repository.BaseRepository
{
    public partial class BaseDbContext : DbContext
    {
        public BaseDbContext()
            : base("name=TourPakistan")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Season> Seasons { get; set; }
    }
}
