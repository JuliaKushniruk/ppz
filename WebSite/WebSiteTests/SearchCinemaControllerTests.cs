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
    public class SearchCinemaControllerTests
    {
        [TestMethod]
        public void IndexTestGet()
        {
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            Mock<IPrincipal> principal = new Mock<IPrincipal>();
            Mock<IMainRepository> repository = new Mock<IMainRepository>();
            Cinema cinema = new Cinema
            {
                Name = "Event Hall KINO",
                Description = "Club'n'Movie",
                Address = "Nekrasova 22",
                Rows = 50,
                Seats = 30
            };
            repository.Setup(x => x.GetCinemas()).Returns(
                new List<Cinema>
                {
                   cinema
                });

            SearchCinemaController controller = new SearchCinemaController(repository.Object);

            var result = (SearchModel)controller.Index().ViewData.Model;
            Assert.AreEqual("Event Hall KINO", result.CinemasFound.ToList()[0].Name);
            Assert.AreEqual("Club'n'Movie", result.CinemasFound.ToList()[0].Description);
            Assert.AreEqual("Club'n'Movie", result.CinemasFound.ToList()[0].Description);
            Assert.AreEqual("Nekrasova 22", result.CinemasFound.ToList()[0].Address);
            Assert.AreEqual(50, result.CinemasFound.ToList()[0].Rows);
            Assert.AreEqual(30, result.CinemasFound.ToList()[0].Seats);
        }

        [TestMethod]
        public void IndexTestPost()
        {
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            Mock<IPrincipal> principal = new Mock<IPrincipal>();
            Mock<IMainRepository> repository = new Mock<IMainRepository>();

            Cinema cinema1 = new Cinema
            {
                Name = "Event Hall KINO",
                Description = "Club'n'Movie",
                Address = "Nekrasova 22",
                Rows = 50,
                Seats = 30
            };

            Cinema cinema2 = new Cinema
            {
                Name = "Kopernik",
                Description = "Old good cinema",
                Address = "Svobody 12",
                Rows = 10,
                Seats = 40
            };

            SearchModel model = new SearchModel
            {
                Name = "Event Hall KINO"
            };

            repository.Setup(x => x.GetCinemas()).Returns(
                new List<Cinema>
                {
                   cinema1, cinema2
                });

            SearchCinemaController controller = new SearchCinemaController(repository.Object);

            var result = (SearchModel)controller.Index(model).ViewData.Model;
            Assert.AreEqual("Event Hall KINO", result.CinemasFound.ToList()[0].Name);
            Assert.AreEqual("Club'n'Movie", result.CinemasFound.ToList()[0].Description);
            Assert.AreEqual("Club'n'Movie", result.CinemasFound.ToList()[0].Description);
            Assert.AreEqual("Nekrasova 22", result.CinemasFound.ToList()[0].Address);
            Assert.AreEqual(50, result.CinemasFound.ToList()[0].Rows);
            Assert.AreEqual(30, result.CinemasFound.ToList()[0].Seats);
        }
    }
}
