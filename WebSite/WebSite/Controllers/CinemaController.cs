using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Concrete;
using WebSite.Models;
using Microsoft.AspNet.Identity;

namespace WebSite.Controllers
{
    public class CinemaController : Controller
    {
        MainRepository repository = new MainRepository();
        // GET: Cinema
        public ActionResult ViewCinema(int cinemaId = 1)
        {
            Cinema cinema = (from cin in repository.Cinemas
                            where cin.CinemaId == cinemaId
                            select cin).FirstOrDefault<Cinema>();
            return View("Cinema", cinema);
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