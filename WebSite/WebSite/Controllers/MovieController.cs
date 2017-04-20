using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Entities;
using WebSite.Concrete;

namespace WebSite.Controllers
{
    public class MovieController : Controller
    {
        MainRepository repository = new MainRepository();
        // GET: Movie
        public ActionResult ViewMovie()
        {
            Movie newMovie = repository.Movies.First<Movie>();

            return View("Movie" , newMovie);
        }
    }
}