using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Concrete;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class EventController : Controller
    {
        MainRepository repository = new MainRepository();
        // GET: Event

        public ActionResult ViewEvent()
        {
            Event newEvent = repository.Events.First<Event>();
            return View("Event", newEvent);
        }

        /*[HttpGet]
        public ViewResult Event()
        {
            return View();
        }*/
        /*[HttpPost]
        public ViewResult f(Models.Event guestResponse)
        {
            //TODO: add model validation (e.g. model.IsValid)

            return View("Event", guestResponse);
        }*/
    }
}