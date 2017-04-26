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
        public IEnumerable<Event> Events { get { return context.Events; } }
        public IEnumerable<Cinema> Cinemas { get { return context.Cinemas; } }

        public void AddEvent(Event cinemaEvent)
        {
            context.Events.Add(cinemaEvent);
            context.SaveChanges();
        }

        public void AddMovie(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        public void AddCinema(Cinema cinema)
        {
            context.Cinemas.Add(cinema);
            context.SaveChanges();
        }
    }
}