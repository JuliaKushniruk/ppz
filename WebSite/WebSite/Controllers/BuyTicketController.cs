using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Concrete;
using WebSite.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Domain.Abstract;

namespace WebSite.Controllers
{
    [Authorize]
    public class BuyTicketController : Controller
    {
        private readonly IMainRepository repository;

        public BuyTicketController(IMainRepository repo)
        {
            repository = repo;
        }

        public ActionResult BuyTicket(int eventId = 0)
        {
            Event selectedEvent = repository.GetEventById(eventId);
            AppUser user = UserManager.FindById(User.Identity.GetUserId());
            if (selectedEvent != null && user != null)
            {
                BuyTicketModel ticket = new BuyTicketModel()
                {
                    EventId = selectedEvent.EventId,
                    EventName = selectedEvent.Name,
                    EventPrice = selectedEvent.Price,
                    MovieName = selectedEvent.Movie.Name,
                    OwnerId = user.Id,
                };
                return View("BuyTicket", ticket);
            }
            else
            {
                return View("BuyTicket");
            }
        }

        [HttpPost]
        public ActionResult BuyTicket(BuyTicketModel model)
        {
            Ticket ticket = new Ticket
            {
                Event = repository.GetEventById(model.EventId),
                Owner = repository.GetUserById(model.OwnerId),
                Row = model.Row,
                Seat = model.Seat
            };
            repository.AddTicket(ticket);
            return RedirectToAction("ViewEvent", "Event", new { EventID = model.EventId });
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