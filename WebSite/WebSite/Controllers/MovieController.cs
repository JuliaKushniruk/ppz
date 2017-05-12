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
    public class MovieController : Controller
    {
        private readonly IMainRepository repository;

        public MovieController(IMainRepository repo)
        {
            repository = repo;
        }

        public ActionResult ViewMovie(int movieId = 1)
        {
            Movie movie = repository.GetMovieById(movieId);
            return View("Movie", movie);
        }
    }
}