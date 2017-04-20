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
        public ActionResult ViewCinema()
        {
          /*  Models.Cinema cinema = new Models.Cinema();
            cinema.Name = "Planeta Kino";
            cinema.Description = "This is Planeta Kino cinema in FORUM LVIV";
            cinema.Address = "vul. Pid dubom 7b";
            cinema.Seats = new Models.Seats(12, 10);
            cinema.Events = new List<Models.Event>();

            Models.Event movieEvent1 = new Models.Event();
            movieEvent1.Author = "Julia";
            movieEvent1.Cinema = cinema;
            movieEvent1.Movie = new Models.Movie();
            movieEvent1.Movie.Name = "Midnight in Paris";
            movieEvent1.IsApproved = true;
            movieEvent1.Price = 40;

            Models.Event movieEvent2 = new Models.Event();
            movieEvent2.Author = "Yuriy";
            movieEvent2.Cinema = cinema;
            movieEvent2.Movie = new Models.Movie();
            movieEvent2.Movie.Name = "Free to play";
            movieEvent2.IsApproved = true;
            movieEvent2.Price = 40;

            cinema.Events.Add(movieEvent1);
            cinema.Events.Add(movieEvent2);
            */
            return View("Cinema");
        }

        /*[HttpPost]
        public ActionResult OpenEvent(Models.Event selectedEvent)
        {
            //TODO: add model validation (e.g. model.IsValid)
            Console.Write("ddf");
            return RedirectToAction("Event", "Event", selectedEvent);
        }*/
    }
}