using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebSite.Models;

namespace WebSite.Infrastructure
{
    public class CinemasSiteContext : IdentityDbContext<AppUser>
    {
        public CinemasSiteContext() : base("entityFramework") { }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Movie> Movies { get; set; }

        static CinemasSiteContext()
        {
            Database.SetInitializer<CinemasSiteContext>(new IdentityDbInit());
        }

        public static CinemasSiteContext Create()
        {
            return new CinemasSiteContext();
        }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<CinemasSiteContext>
    {
        protected override void Seed(CinemasSiteContext context)
        {
            PerformInitialSetup(context); base.Seed(context);
        }

        public void PerformInitialSetup(CinemasSiteContext context)
        {
            // initial configuration will go here    
        }
    }
}