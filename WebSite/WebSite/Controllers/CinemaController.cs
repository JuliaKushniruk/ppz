using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class CinemaController : Controller
    {
        // GET: Cinema
        public ActionResult Index()
        {
            Models.Cinema cinema = new Models.Cinema();
            cinema.Name = "Planeta Kino";
            cinema.Description = "This is Planeta Kino cinema in FORUM LVIV";
            cinema.Address = "vul. Pid dubom 7b";
            cinema.Seats = new Models.Seats(12, 10);
            cinema.Events = new List<Models.Event>();

            Models.Event movieEvent1 = new Models.Event();
            movieEvent1.Author = "Julia";
            movieEvent1.Cinema = "Forum Lviv";
            movieEvent1.Movie = "Midnight in Paris";
            movieEvent1.IsApproved = true;
            movieEvent1.Price = 40;

            Models.Event movieEvent2 = new Models.Event();
            movieEvent2.Author = "Yuriy";
            movieEvent2.Cinema = "Forum Lviv";
            movieEvent2.Movie = "Free to play";
            movieEvent2.IsApproved = true;
            movieEvent2.Price = 40;

            cinema.Events.Add(movieEvent1);
            cinema.Events.Add(movieEvent2);

            return View("Cinema", cinema);
        }
    }
}