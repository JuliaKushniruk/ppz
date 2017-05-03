﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebSite.Models;

namespace WebSite.Infrastructure
{
    public class CinemasSiteContext : IdentityDbContext<AppUser>
    {
        public CinemasSiteContext() : base("WebSite") { }

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
            base.Seed(context);
            Event eventt = new Event()
            {
                CinemaId = 1,
                MovieId = 2,
                Author = "Yura",
                IsApproved = false,
                Price = 50

            };
            context.Events.Add(eventt);
            Event event2 = new Event()
            {
                CinemaId = 2,
                MovieId = 5,
                Author = "Yarko",
                IsApproved = true,
                Price = 100

            };
            context.Events.Add(event2);
            Event event3 = new Event()
            {
                CinemaId = 3,
                MovieId = 4,
                Author = "Yuliya",
                IsApproved = true,
                Price = 75

            };
            context.Events.Add(event3);

            Cinema cinema = new Cinema()
            {
                Name = "Cinema Hall",
                Description = "The most modern cinema you've ever seen.",
                Address = "Times Square 21,7",
                Rows = 20,
                Seats = 30
            };
            context.Cinemas.Add(cinema);
            Cinema cinema2 = new Cinema()
            {
                Name = "Kopernik",
                Description = "Old good cinema.",
                Address = "Teatralna str. 21",
                Rows = 30,
                Seats = 20
            };
            context.Cinemas.Add(cinema2);
            Cinema cinema3 = new Cinema()
            {
                Name = "Event Hall KINO",
                Description = "Club'n'Movie",
                Address = "Nekrasova 22",
                Rows = 50,
                Seats = 30
            };
            context.Cinemas.Add(cinema3);
            base.Seed(context);
        }
        
        public void PerformInitialSetup(CinemasSiteContext context)
        {
            // initial configuration will go here    
        }
    }
}