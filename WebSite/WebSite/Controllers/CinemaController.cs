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

        public ActionResult ViewCinema(int cinemaId = 0)
        {
            CinemaPageModel model = new CinemaPageModel();
            model.CurrentCinema = (from cin in repository.Cinemas
                            where cin.CinemaId == cinemaId
                            select cin).FirstOrDefault<Cinema>();
            model.Events = (from even in repository.Events
                            where even.Cinema == model.CurrentCinema
                            select even);
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