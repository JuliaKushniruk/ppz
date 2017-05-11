using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Concrete;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class EventController : Controller
    {
        private MainRepository repository = new MainRepository();

        [AllowAnonymous]
        public ViewResult ViewEvent(int EventID = 0)
        {
            Event even = (from eventss in repository.Events where eventss.EventId == EventID select eventss).FirstOrDefault();

            EventLikedModel eventsToDisplay;

            eventsToDisplay =
                new EventLikedModel
                {
                    EventId = even.EventId,
                    Cinema = even.Cinema.Name,
                    Film = even.Movie.Name,
                    IsApproved = even.IsApproved,
                    Price = even.Price,
                    Author = even.Author,
                    IsLiked = even.Users.FirstOrDefault(x => x.Id == User.Identity.GetUserId()) != null,
                    LikesAmount = even.Users.Count
                };

            return View("Event", eventsToDisplay);
        }

        [Authorize]
        public ActionResult LikeEvent(EventLikedModel eventModel)
        {
            var result = repository.GetEventById(eventModel.EventId);
            var user = repository.GetUserById(User.Identity.GetUserId());
            result.Users.Add(user);
            user.Events.Add(result);
            repository.Save();
            eventModel.LikesAmount++;
            return RedirectToAction("ViewEvent", new { result.EventId });
        }

        [Authorize]
        public ActionResult DislikeEvent(EventLikedModel eventModel)
        {
            var result = repository.GetEventById(eventModel.EventId);
            var user = repository.GetUserById(User.Identity.GetUserId());
            result.Users.Remove(user);
            repository.UpdateEvent(result);
            eventModel.LikesAmount--;
            return RedirectToAction("ViewEvent", new { result.EventId });
        }
    }
}