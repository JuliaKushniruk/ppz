using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Domain.Abstract
{
    public interface IMainRepository
    {
        Event GetEventById(int EventId);
        IEnumerable<Event> GetEvents();
        Cinema GetCinemaById(int CinemaId);
        IEnumerable<Cinema> GetCinemas();
        Movie GetMovieById(int MovieId);
        IEnumerable<Movie> GetMovies();
        AppUser GetUserById(string userId);
        IEnumerable<AppUser> GetUsers();
        void UpdateEvent(Event eventObj);
        void UpdateUser(AppUser user);
        void AddEvent(Event cinemaEvent);
        void AddMovie(Movie movie);
        void AddCinema(Cinema cinema);
        void AddTicket(Ticket ticket);
        void DeleteEvent(Event cinemaEvent);
        void DeleteMovie(Movie movie);
        void DeleteCinema(Cinema cinema);
        void Save();

    }
}
