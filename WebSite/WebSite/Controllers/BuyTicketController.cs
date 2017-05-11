using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Concrete;
using WebSite.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace WebSite.Controllers
{
    [Authorize]
    public class BuyTicketController : Controller
    {
        private MainRepository repository = new MainRepository();

        public ActionResult BuyTicket(int eventId = 0)
        {
            Event selectedEvent = repository.GetEventById(eventId);
            AppUser user = UserManager.FindById(User.Identity.GetUserId());
            if (selectedEvent != null && user != null)
            {
                Ticket ticket = new Ticket()
                {
                    Event = selectedEvent,
                    Owner = user
                };
                return View("BuyTicket", ticket);
            }
            else
            {
                return View("BuyTicket");
            }     
        }

        [HttpPost]
        public ActionResult BuyTicket(Ticket model)
        {
            repository.AddTicket(model);
            return RedirectToAction("ViewEvent", "Event", new { EventID = model.Event.EventId});
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}