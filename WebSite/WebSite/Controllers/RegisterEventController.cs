using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Concrete;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class RegisterEventController : Controller
    {
        MainRepository repository = new MainRepository();

        [HttpGet]
        public ViewResult Register(int cinemaId = 0)
        {
            RegisterEventModel model = new RegisterEventModel();
            model.CinemaId = cinemaId;
            return View("RegisterEvent", model);
        }

        [HttpPost]
        public string Register(RegisterEventModel model)
        {
            repository.AddMovie(model.Movie);
            Event cinemaEvent = new Event();
            cinemaEvent.Author = "Yarko";
            cinemaEvent.CinemaId = model.CinemaId;
            cinemaEvent.MovieId = model.Movie.MovieId;
            repository.AddEvent(cinemaEvent);
            return "Event added";
        }
    }
}