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
        public ViewResult ViewEvent(int? CinemaId )
        {
            IEnumerable<Event> events;
            if (CinemaId == null)
            {
                events = from eventss in repository.Events
                         select eventss;
            }
            else
            {
                events = from eventss in repository.Events
                         where eventss.Cinema.CinemaId == CinemaId
                         select eventss;
            }
            List<EventLikedModel> eventsToDisplay = new List<EventLikedModel>();
            foreach (var e in events)
            {
                eventsToDisplay.Add(
                    new EventLikedModel
                    {
                        EventId = e.EventId,
                        Cinema = e.Cinema.Name,
                        Film = e.Movie.Name,
                        IsApproved = e.IsApproved,
                        Price = e.Price,
                        Author = e.Author,
                        IsLiked = e.Users.FirstOrDefault(x => x.Id == User.Identity.GetUserId()) != null,
                        LikesAmount = e.Users.Count
                    });
            }
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
            return RedirectToAction("ViewEvent", new { result.Cinema.CinemaId });
        }

        [Authorize]
        public ActionResult DislikeEvent(EventLikedModel eventModel)
        {
            var result = repository.GetEventById(eventModel.EventId);
            var user = repository.GetUserById(User.Identity.GetUserId());
            result.Users.Remove(user);
            repository.UpdateEvent(result);
            eventModel.LikesAmount--;
            return RedirectToAction("ViewEvent", new { result.Cinema.CinemaId });
        }
    }
}