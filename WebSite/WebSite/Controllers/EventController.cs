using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using Domain.Concrete;
using Domain.Entities;
using Domain.Abstract;

namespace WebSite.Controllers
{
    public class EventController : Controller
    {
        private readonly IMainRepository repository;

        public EventController(IMainRepository repo)
        {
            repository = repo;
        }

        [AllowAnonymous]
        public ViewResult ViewEvent(int EventID = 0)
        {
            Event even = repository.GetEventById(EventID);

            EventLikedModel eventsToDisplay;

            eventsToDisplay =
                new EventLikedModel
                {
                    EventId = even.EventId,
                    Cinema = even.Cinema.Name,
                    CinemaID = even.Cinema.CinemaId,
                    Film = even.Movie.Name,
                    IsApproved = even.IsApproved,
                    Author = even.Author,
                    IsLiked = even.Users.FirstOrDefault(x => x.Id == User.Identity.GetUserId()) != null,
                    LikesAmount = even.Users.Count,
                    MovieId = even.Movie.MovieId
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
        
        public ActionResult ManageEvent(int EventID = 0)
        {
            Event even = (from eventss in repository.GetEvents() where eventss.EventId == EventID select eventss).FirstOrDefault();
            EventLikedModel eventsToDisplay;

            eventsToDisplay =
                new EventLikedModel
                {
                    EventId = even.EventId,
                    Cinema = even.Cinema.Name,
                    CinemaID = even.Cinema.CinemaId,
                    Film = even.Movie.Name,
                    IsApproved = even.IsApproved,
                    Author = even.Author,
                    IsLiked = even.Users.FirstOrDefault(x => x.Id == User.Identity.GetUserId()) != null,
                    LikesAmount = even.Users.Count
                };            
            return View("ApproveEvent",eventsToDisplay);
        }
       
        public ActionResult ApproveEvent(EventLikedModel eventModel)
        {
            var result = repository.GetEventById(eventModel.EventId);
            result.IsApproved = true;
            result.Price = eventModel.Price;
            repository.UpdateEvent(result);
            return RedirectToAction("ViewCinema" , "Cinema",new { result.Cinema.CinemaId});
        }
        public ActionResult DisApproveEvent(EventLikedModel eventModel)
        {
            var result = repository.GetEventById(eventModel.EventId);
            result.IsApproved = false;
            result.Price = eventModel.Price;
            return RedirectToAction("ViewCinema", "Cinema", new { result.Cinema.CinemaId });
        }
    }
}