using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Domain.Entities;
using Domain.Abstract;

namespace Domain.Concrete
{
    public class MainRepository: IMainRepository
    {
        private CinemasSiteContext context = new CinemasSiteContext();

        //public IEnumerable<AppUser> Users { get { return context.Users; } }
        //public IEnumerable<Movie> Movies { get { return context.Movies; } }
        //public IEnumerable<Event> Events { get { return context.Events; } }
        //public IEnumerable<Cinema> Cinemas { get { return context.Cinemas; } }
        // public IEnumerable<Ticket> Tickets { get { return context.Tickets; } }

        public Event GetEventById(int EventId)
        {
            return context.Events.Find(EventId);
        }
        public IEnumerable<Event> GetEvents()
        {
            var events = from eve in context.Events select eve;
            return events.ToList();
        }
        public Cinema GetCinemaById(int CinemaId)
        {
            return context.Cinemas.Find(CinemaId);
        }
        public IEnumerable<Cinema> GetCinemas()
        {
            var cinemas = from cinem in context.Cinemas select cinem;
            return cinemas.ToList();
        }
        public Movie GetMovieById(int MovieId)
        {
            return context.Movies.Find(MovieId);
        }
        public IEnumerable<Movie> GetMovies()
        {
            var movies = from movi in context.Movies select movi;
            return movies.ToList();
        }
        public AppUser GetUserById(string userId)
        {
            return context.Users.FirstOrDefault(x => x.Id == userId);
        }
        public IEnumerable<AppUser> GetUsers()
        {
            var users = from user in context.Users select user;
            return users.ToList();
        }

        public void UpdateEvent(Event eventObj)
        {
            context.Entry(eventObj).State = EntityState.Modified;
            Save();
        }
        public void UpdateUser(AppUser user)
        {
            context.Entry(user).State = EntityState.Modified;
            Save();
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
        public void AddTicket(Ticket ticket)
        {
            context.Tickets.Add(ticket);
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