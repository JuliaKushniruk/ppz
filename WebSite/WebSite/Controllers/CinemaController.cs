using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class CinemaController : Controller
    {
        // GET: Cinema
        public ActionResult Index()
        {
            return View("Cinema");
        }
    }
}