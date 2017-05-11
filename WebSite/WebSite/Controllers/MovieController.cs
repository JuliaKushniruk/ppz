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
    public class MovieController : Controller
    {
        private MainRepository repository = new MainRepository();

        public ActionResult ViewMovie(int movieId = 1)
        {
            var movies = repository.GetMovies();

            return View("Movie", movies);
        }
    }
}