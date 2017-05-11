﻿using System;
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
        private MainRepository repository = new MainRepository();

        public ActionResult ViewMovie(int movieId = 1)
        {
            var movies = repository.Movies;

            return View("Movie", movies);
        }
    }
}