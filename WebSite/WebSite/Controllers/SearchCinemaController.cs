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
    public class SearchCinemaController : Controller
    {
        private readonly IMainRepository repository;

        public SearchCinemaController(IMainRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public ViewResult Index()
        {
            SearchModel model = new SearchModel();
            model.CinemasFound = from cinema in repository.GetCinemas()
                                 select cinema;
            return View("Search", model);
        }

        [HttpPost]
        public ViewResult Index(SearchModel model)
        {
            model.CinemasFound = from cinema in repository.GetCinemas()
                                 where cinema.Name == model.Name
                                 select cinema;
            return View("Search", model);
        }
    }
}