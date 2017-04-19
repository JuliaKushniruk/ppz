using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult ViewMovie()
        {
            Movie newMovie = new Movie();
            newMovie.Name = "RoKi";
            newMovie.Year = 1997;
            newMovie.Genre = "Strange";
            newMovie.Author = "Avildsen";
            newMovie.Cast = new List<string> { "Stalone", "Vesers" };
            newMovie.Description = "Cool movie";

            return View("Movie" , newMovie);
        }
    }
}