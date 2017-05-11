using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Domain.Concrete;
using Domain.Entities;

namespace WebSite.Controllers
{
    [Authorize]
    public class RegisterCinemaController : Controller
    {
        private MainRepository repository = new MainRepository();

        [HttpGet]
        public ViewResult Register()
        {
            RegisterCinemaModel model = new RegisterCinemaModel();
            //model.Cinema;
            model.CurrentUser =repository.GetUserById( User.Identity.GetUserId());
            return View("RegisterCinema",model);
        }

        [HttpPost]
        public ActionResult Register(RegisterCinemaModel model)
        {
            AppUser user = repository.GetUserById(User.Identity.GetUserId());
            if (user != null)
                model.Cinema.Moderator =user;
            repository.AddCinema(model.Cinema);
            UserManager.AddToRoleAsync(User.Identity.GetUserId(), "CinemaModerator");
            return RedirectToAction("ViewUser", "UserPage", new { userId = User.Identity.GetUserId() });
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