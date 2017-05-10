using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Infrastructure;
using WebSite.Concrete;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace WebSite.Controllers
{
    public class UserPageController : Controller
    {
        MainRepository repository = new MainRepository();

        [Authorize]
        public string Index()
        {
            return "index page";
        }

        public async Task<ActionResult> ViewUser(string userId = "user_id")
        {
            AppUser user = await UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                UserPageModel model = new UserPageModel();
                model.User = user;
                //model.ModeratedCinemas = from cinema in repository.Cinemas
                //                         where (cinema.ModeratorId == user.Id)
                //                         select cinema;
                model.ModeratedCinemas = from cinema in repository.Cinemas
                                         select cinema;
                model.CurrentUserId = User.Identity.GetUserId();
                return View("UserPage", model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "CinemaModerator,Administrator")]
        public ActionResult DeleteCinema(int cinemaId = 0)
        {
            Cinema cinemaToDelete = repository.GetCinemaById(cinemaId);
            if (cinemaToDelete != null)
            {
                repository.DeleteCinema(cinemaToDelete);
                return RedirectToAction("ViewUser", "UserPage", new { userId = User.Identity.GetUserId() });
            }
            else
            {
                return RedirectToAction("Index");
            }
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