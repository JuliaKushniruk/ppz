using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using Domain.Concrete;
using Domain.Entities;

namespace WebSite.Controllers
{
    [Authorize]
    public class RegisterEventController : Controller
    {
        private MainRepository repository = new MainRepository();

        [HttpGet]
        public ViewResult Register(int cinemaId = 0)
        {
            RegisterEventModel model = new RegisterEventModel();
            model.CinemaId = cinemaId;
            return View("RegisterEvent", model);
        }

        [HttpPost]
        public ActionResult Register(RegisterEventModel model)
        {
            repository.AddMovie(model.Movie);
            Event cinemaEvent = new Event();
            cinemaEvent.Author = repository.GetUserById(User.Identity.GetUserId()).UserName;
            cinemaEvent.Cinema = repository.GetCinemaById(model.CinemaId);
            cinemaEvent.Movie = model.Movie;
            cinemaEvent.Price = model.Price;
            repository.AddEvent(cinemaEvent);
            return RedirectToAction("ViewEvent", "Event",new { cinemaEvent.Cinema.CinemaId });
        }
    }
}