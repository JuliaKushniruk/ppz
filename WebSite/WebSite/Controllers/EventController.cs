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
        public ViewResult Index()
        {
            Models.Event movieEvent = new Models.Event();
            movieEvent.Author = "Julia";
            movieEvent.Cinema = "Movie palace";
            movieEvent.Movie = "Midnight in Paris";
            movieEvent.IsApproved = true;
            movieEvent.Price = 40;
            return View("Event", movieEvent);
        }
    }
}