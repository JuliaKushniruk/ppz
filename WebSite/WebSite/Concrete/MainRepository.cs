using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Entities;
using WebSite.Models;

namespace WebSite.Concrete
{
    public class MainRepository
    {
        private CinemasSiteContext context = new CinemasSiteContext();

        public IEnumerable<Movie> Movies { get { return context.Movies; } }
    }
}