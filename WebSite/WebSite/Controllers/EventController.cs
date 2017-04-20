using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index(int a)
        {
           /* Models.Event movieEvent = new Models.Event();
            movieEvent.Author = "Julia";
            movieEvent.Cinema = new Models.Cinema();
            movieEvent.Cinema.Name = "Movie Palace";
            movieEvent.Movie = new Models.Movie();
            movieEvent.Movie.Name = "Midnight in Paris";
            movieEvent.IsApproved = true;
            movieEvent.Price = 40;*/
            return View("Event");
        }

        /*[HttpGet]
        public ViewResult Event()
        {
            return View();
        }*/
        /*[HttpPost]
        public ViewResult f(Models.Event guestResponse)
        {
            //TODO: add model validation (e.g. model.IsValid)

            return View("Event", guestResponse);
        }*/
    }
}