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
    public class SearchCinemaController : Controller
    {
        private MainRepository repository = new MainRepository();

        [HttpGet]
        public ActionResult Index()
        {
            SearchModel model = new SearchModel();
            model.CinemasFound = from cinema in repository.GetCinemas()
                                 select cinema;
            return View("Search", model);
        }

        [HttpPost]
        public ActionResult Index(SearchModel model)
        {
            model.CinemasFound = from cinema in repository.GetCinemas()
                                 where cinema.Name == model.Name
                                 select cinema;
            return View("Search", model);
        }
    }
}