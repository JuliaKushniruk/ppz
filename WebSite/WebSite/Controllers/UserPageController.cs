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
                return View("UserPage", user);
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