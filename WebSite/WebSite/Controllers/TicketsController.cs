using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Domain.Concrete;
using Domain.Entities;
using WebSite.Models;

namespace WebSite.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private MainRepository repository = new MainRepository();

        public ActionResult ViewTickets()
        {
            ViewTicketsModel model = new ViewTicketsModel
            {
                Tickets = repository.GetTicketsByUserId(User.Identity.GetUserId())
            };        
            return View("ViewTickets", model);
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