using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using Domain.Concrete;
using Domain.Entities;
using Domain.Abstract;


namespace WebSite.Controllers
{
    [Authorize]
    public class RegisterEventController : Controller
    {
        private readonly IMainRepository repository;

        public RegisterEventController(IMainRepository repo)
        {
            repository = repo;
        }

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
            repository.AddEvent(cinemaEvent);
            return RedirectToAction("ViewEvent", "Event",new { cinemaEvent.Cinema.CinemaId });
        }
    }
}