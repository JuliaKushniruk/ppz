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
    public class SearchEventsController : Controller
    {
        private IMainRepository repository;

        public SearchEventsController(IMainRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public ActionResult SearchEvents()
        {
            SearchEventModel model = new SearchEventModel();
            model.EventsFound = from ev in repository.GetEvents()
                                select ev;
            return View("Search", model);
        }

        [HttpPost]
        public ActionResult SearchEvents(SearchEventModel model)
        {
            model.EventsFound = from ev in repository.GetEvents()
                                where ev.Name.ToLower().Contains(model.Name.ToLower())
                                select ev;
            return View("Search", model);
        }
    }
}