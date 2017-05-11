using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Domain.Entities;

namespace Domain.Concrete
{
    public class CinemasSiteContext : IdentityDbContext<AppUser>
    {
        public CinemasSiteContext() : base("WebbbbSite") { }

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>().ToTable("Users");           
        }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<CinemasSiteContext>
    {
        protected override void Seed(CinemasSiteContext context)
        {
            AppUserManager userManager = new AppUserManager(new UserStore<AppUser>(context));

            string userName = "username";
            string email = "email@qqq";
            string pass = "123Qqq";
            bool isbanned = false;
            var user = userManager.FindByName(userName);
            if (user == null)
            {
                userManager.Create(new AppUser { UserName = userName, Email = email,IsBanned = isbanned }, pass);
                user = userManager.FindByName(userName);
            }

            Movie movie = new Movie()
            {
                Name = "Midnight in Paris",
                Description = "While on a trip to Paris with his fiancée's family, a nostalgic screenwriter finds himself mysteriously going back to the 1920s everyday at midnight.",
                Year = 2011,
                Genre = "Drama",
                Author = "Woodie Allen",
                Cast = "Owen Wilson, Rachel McAdams, Kathy Bates"
            };
            context.Movies.Add(movie);

            Movie movie2 = new Movie()
            {
                Name = "Scent of a Woman",
                Description = "A prep school student needing money agrees to \"babysit\" a blind man, but the job is not at all what he anticipated.",
                Year = 1992,
                Genre = "Drama",
                Author = "Martin Brest",
                Cast = "Al Pacino, Chris O'Donnell, James Rebhorn"
            };
            context.Movies.Add(movie2);

            Movie movie3 = new Movie()
            {
                Name = "A Beautiful Mind",
                Description = "After John Nash, a brilliant but asocial mathematician, accepts secret work in cryptography, his life takes a turn for the nightmarish.",
                Year = 2001,
                Genre = "Biography, Drama",
                Author = "Ron Howard",
                Cast = " Russell Crowe, Ed Harris, Jennifer Connelly"
            };
            context.Movies.Add(movie3);

            Movie movie4 = new Movie()
            {
                Name = "Assassin's Creed",
                Description = "When Callum Lynch explores the memories of his ancestor Aguilar and gains the skills of a Master Assassin, he discovers he is a descendant of the secret Assassins society.",
                Year = 2016,
                Genre = "Action, Adventure, Drama",
                Author = "Justin Kurzel",
                Cast = " Michael Fassbender, Marion Cotillard, Jeremy Irons"
            };
            context.Movies.Add(movie4);


            Cinema cinema = new Cinema()
            {
                Name = "Cinema Hall",
                Description = "The most modern cinema you've ever seen.",
                Address = "Times Square 21,7",
                Rows = 20,
                Seats = 30,
                Moderator = user
            };
            context.Cinemas.Add(cinema);
            Cinema cinema2 = new Cinema()
            {
                Name = "Kopernik",
                Description = "Old good cinema.",
                Address = "Teatralna str. 21",
                Rows = 30,
                Seats = 20,
                Moderator = user
            };
            context.Cinemas.Add(cinema2);
            Cinema cinema3 = new Cinema()
            {
                Name = "Event Hall KINO",
                Description = "Club'n'Movie",
                Address = "Nekrasova 22",
                Rows = 50,
                Seats = 30,
                Moderator = user
            };

            context.Cinemas.Add(cinema3);

            Event eventt = new Event()
            {
                Cinema = cinema,
                Movie = movie,
                IsApproved = false,
                Price = 50,
                Author = user.UserName,
                Name ="Relax"

            };
            context.Events.Add(eventt);
            Event event2 = new Event()
            {
                Movie = movie3,
                Cinema = cinema2,
                IsApproved = true,
                Price = 100,
                Author = user.UserName,
                Name = "Be Happy"
            };
            context.Events.Add(event2);
            Event event3 = new Event()
            {
                Movie = movie2,
                Cinema = cinema,
                IsApproved = true,
                Price = 75,
                Author = user.UserName,
                Name = "Funny"
            };
            context.Events.Add(event3);

            string registeredUser = "RegisteredUser";
            string cinemaModerator = "CinemaModerator";
            string administrator = "Administrator";

            AppRoleManager roleManager = new AppRoleManager(new RoleStore<AppRole>(context));

            if (!roleManager.RoleExists(registeredUser))
            {
                roleManager.Create(new AppRole(registeredUser));
            }
            if (!roleManager.RoleExists(cinemaModerator))
            {
                roleManager.Create(new AppRole(cinemaModerator));
            }
            if (!roleManager.RoleExists(administrator))
            {
                roleManager.Create(new AppRole(administrator));
            }


            base.Seed(context);
        }

        public void PerformInitialSetup(CinemasSiteContext context)
        {
            // initial configuration will go here    
        }

    }
}