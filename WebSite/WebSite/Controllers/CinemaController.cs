using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using Microsoft.AspNet.Identity;
using Domain.Concrete;
using Domain.Entities;
using Domain.Abstract;

namespace WebSite.Controllers
{
    public class CinemaController : Controller
    {
        private readonly IMainRepository repository;

        public CinemaController(IMainRepository repo)
        {
            repository = repo;
        }

        public ActionResult ViewCinema(int cinemaId = 0)
        {
            CinemaPageModel model = new CinemaPageModel();
            model.CurrentCinema = (from cin in repository.GetCinemas()
                            where cin.CinemaId == cinemaId
                            select cin).FirstOrDefault<Cinema>();
            model.Events = (from even in repository.GetEvents()
                            where even.Cinema == model.CurrentCinema
                            select even);
            model.IsModerator = User.Identity.GetUserId() == model.CurrentCinema.Moderator.Id;
            return View("Cinema", model);
        }

        [Authorize(Roles = "CinemaModerator")]
        public ActionResult DeleteCinema(int cinemaId = 0)
        {
            Cinema cinemaToDelete = repository.GetCinemaById(cinemaId);
           // if (User.Identity.GetUserId() == cinemaToDelete.ModeratorId) ;
                if (cinemaToDelete != null){
                repository.DeleteCinema(cinemaToDelete);
                return RedirectToAction("Index", "SearchCinema");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}