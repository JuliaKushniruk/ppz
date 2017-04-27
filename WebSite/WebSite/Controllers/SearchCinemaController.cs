﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Concrete;

namespace WebSite.Controllers
{
    public class SearchCinemaController : Controller
    {
        MainRepository repository = new MainRepository();
        // GET: SearchCinema
        [HttpGet]
        public ActionResult Index()
        {
            SearchModel model = new SearchModel();
            model.CinemasFound = from cinema in repository.Cinemas
                                 select cinema;
            return View("Search", model);
        }

        [HttpPost]
        public ActionResult Index(SearchModel model)
        {
            model.CinemasFound = from cinema in repository.Cinemas
                                 where cinema.Name == model.Name
                                 select cinema;
            return View("Search", model);
        }
    }
}