using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebSite.Infrastructure;
using WebSite.Models;

namespace WebSite.Concrete
{
    public class MainRepository
    {
        private CinemasSiteContext context = new CinemasSiteContext();

        public IEnumerable<AppUser> Users { get { return context.Users; } }
        public IEnumerable<Movie> Movies { get { return context.Movies; } }
        public IEnumerable<Event> Events { get { return context.Events; } }
        public IEnumerable<Cinema> Cinemas { get { return context.Cinemas; } }

        public Event GetEventById(int EventId)
        {
            return context.Events.Find(EventId);
        }
        public Cinema GetCinemaById(int CinemaId)
        {
            return context.Cinemas.Find(CinemaId);
        }
        public Movie GetMovieById(int MovieId)
        {
            return context.Movies.Find(MovieId);
        }
        public AppUser GetUserById(string userId)
        {
            return context.Users.FirstOrDefault(x => x.Id == userId);
        }
        public void UpdateEvent(Event events)
        {
            context.Entry(events).State = EntityState.Modified;
        }
        public void AddEvent(Event cinemaEvent)
        {
            context.Events.Add(cinemaEvent);
            Save();
        }
        public void AddMovie(Movie movie)
        {
            context.Movies.Add(movie);
            Save();
        }        
        public void AddCinema(Cinema cinema)
        {
            context.Cinemas.Add(cinema);
            Save();
        }
        public void DeleteEvent(Event cinemaEvent)
        {
            context.Events.Remove(cinemaEvent);
            Save();
        }
        public void DeleteMovie(Movie movie)
        {
            context.Movies.Remove(movie);
            Save();
        }
        public void DeleteCinema(Cinema cinema)
        {
            context.Cinemas.Remove(cinema);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}