using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Concrete;
using WebSite.Models;
using WebSite.Infrastructure;
using Microsoft.AspNet.Identity.Owin;

namespace WebSite.Controllers
{
    [Authorize]
    public class RegisterCinemaController : Controller
    {
        MainRepository repository = new MainRepository();

        [HttpGet]
        public ViewResult Register()
        {
            return View("RegisterCinema");
        }

        [HttpPost]
        public string Register(Cinema model)
        {
            repository.AddCinema(model);
            // We should add current user to Role if user isn't a moderator already
            // UserManager.AddToRoleAsync("id", "CinemaModerator");
            return "Cinema added";
        }

        private AppUserManager UserManager {
            get {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        private AppRoleManager RoleManager {
            get {
                return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }
    }
}