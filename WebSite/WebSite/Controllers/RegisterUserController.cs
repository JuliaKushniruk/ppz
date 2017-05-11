using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using WebSite.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Domain.Concrete;
using Domain.Entities;

namespace WebSite.Controllers
{
    public class RegisterUserController : Controller
    {
        // GET: RegisterPage
        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<ActionResult> Index(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                AppUser registeredUser = await UserManager.FindAsync(user.UserName, model.Password);
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, ident);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View("Register", model);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}