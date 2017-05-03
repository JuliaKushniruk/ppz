using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Infrastructure;
using WebSite.Concrete;

namespace WebSite.Controllers
{
    public class MovieController : Controller
    {
        MainRepository repository = new MainRepository();
        // GET: Movie
        public ActionResult ViewMovie(int movieId = 1)
        {
            Movie newMovie = (from movie in repository.Movies
                              where movie.MovieId == movieId
                              select movie).FirstOrDefault<Movie>();

            return View("Movie", newMovie);
        }
    }
}