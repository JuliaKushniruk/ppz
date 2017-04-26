using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Concrete;
using WebSite.Models;

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

    }
}