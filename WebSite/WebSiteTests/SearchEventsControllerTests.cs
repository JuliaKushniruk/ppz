using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Domain.Entities;
using Moq;
using WebSite.Controllers;
using System.Web.Mvc;
using System.Security.Principal;
using WebSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebSiteTests
{
    [TestClass]
    public class SearchEventsControllerTests
    {
        [TestMethod]
        public void SearchEventsGetTest()
        {
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            Mock<IPrincipal> principal = new Mock<IPrincipal>();
            Mock<IMainRepository> repository = new Mock<IMainRepository>();
            Cinema cinema = new Cinema();
            Movie movie = new Movie();
            AppUser user = new AppUser { UserName = "user" };
            Event eventt = new Event()
            {
                Cinema = cinema,
                Movie = movie,
                IsApproved = false,
                Price = 50,
                Author = user.UserName,
                Name = "Relax"
            };
            repository.Setup(x => x.GetEvents()).Returns(
                new List<Event>
                {
                   eventt
                });

            SearchEventsController controller = new SearchEventsController(repository.Object);

            var result = (SearchEventModel)controller.SearchEvents().ViewData.Model;
            Assert.AreEqual("Relax", result.EventsFound.ToList()[0].Name);
            Assert.AreEqual(50, result.EventsFound.ToList()[0].Price);
            Assert.AreEqual("user", result.EventsFound.ToList()[0].Author);
            Assert.AreEqual(false, result.EventsFound.ToList()[0].IsApproved);
            Assert.AreEqual(movie, result.EventsFound.ToList()[0].Movie);
            Assert.AreEqual(cinema, result.EventsFound.ToList()[0].Cinema);
        }

        [TestMethod]
        public void SearchEventsPostTest()
        {
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            Mock<IPrincipal> principal = new Mock<IPrincipal>();
            Mock<IMainRepository> repository = new Mock<IMainRepository>();
            Cinema cinema1 = new Cinema();
            Cinema cinema2 = new Cinema();
            Movie movie1 = new Movie();
            Movie movie2 = new Movie();
            AppUser user1 = new AppUser { UserName = "user1" };
            AppUser user2 = new AppUser { UserName = "user2" };
            Event event1 = new Event
            {
                Cinema = cinema1,
                Movie = movie1,
                IsApproved = false,
                Price = 50,
                Author = user1.UserName,
                Name = "Relax"
            };

            Event event2 = new Event
            {
                Movie = movie2,
                Cinema = cinema2,
                IsApproved = true,
                Price = 100,
                Author = user2.UserName,
                Name = "Be Happy"
            };

            SearchEventModel model = new SearchEventModel
            {
                Name = "relax"
            };

            repository.Setup(x => x.GetEvents()).Returns(
                new List<Event>
                {
                   event1, event2
                });

            SearchEventsController controller = new SearchEventsController(repository.Object);

            var result = (SearchEventModel)controller.SearchEvents(model).ViewData.Model;
            Assert.AreEqual(cinema1, result.EventsFound.ToList()[0].Cinema);
            Assert.AreEqual(movie1, result.EventsFound.ToList()[0].Movie);
            Assert.AreEqual(false, result.EventsFound.ToList()[0].IsApproved);
            Assert.AreEqual("user1", result.EventsFound.ToList()[0].Author);
            Assert.AreEqual("Relax", result.EventsFound.ToList()[0].Name);

        }
    }
}
