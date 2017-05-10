using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using WebSite.Models;
using WebSite.Concrete;
using System.Threading.Tasks;

namespace WebSite.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class BannedUsersController : Controller
    {
        MainRepository repository = new MainRepository();

        public ActionResult ViewBannedUsers()
        {
            BannedUsersModel model = new BannedUsersModel();
            model.BannedUsers = UserManager.Users;
            //where user.isBanned
            return View("BannedUsers", model);
        }

        public async Task<ActionResult> Unban(string userId = "user_id")
        {
            AppUser user = await UserManager.FindByIdAsync(userId);
            if (user != null)
            {
         //       user.isBanned = false;
         //       repository.UpdateUser(user);
            }
            return RedirectToAction("ViewBannedUsers");
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