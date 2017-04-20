using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebSite.Models;

namespace WebSite.Entities
{
    public class CinemasSiteContext : DbContext
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }    
}