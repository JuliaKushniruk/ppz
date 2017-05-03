using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Concrete;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class RegisterCinemaController : Controller
    {
        MainRepository repository = new MainRepository();

        [Authorize]
        [HttpGet]
        public ViewResult Register()
        {
            return View("RegisterCinema");
        }

        [Authorize]
        [HttpPost]
        public string Register(Cinema model)
        {
            repository.AddCinema(model);
            return "Cinema added";
        }
    }
}