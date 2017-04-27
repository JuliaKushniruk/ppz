using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using WebSite.Infrastructure;
using System.Web;
using WebSite.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace WebSite.Controllers
{
    public class RegisterPageController : Controller
    {
        // GET: RegisterPage
        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<ActionResult> Index(RegisterPageModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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
    }
}