using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Moq;
using System.Security.Principal;
using Domain.Abstract;
using Domain.Entities;
using WebSite.Controllers;
using WebSite.Models;

namespace WebSiteTests
{
    [TestClass]
    public class RegisterEventControllerTests
    {
        [TestMethod]
        public void RegisterEventGetTest()
        {
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            Mock<IPrincipal> principal = new Mock<IPrincipal>();

            Mock<IMainRepository> repository = new Mock<IMainRepository>();

            RegisterEventController controller = new RegisterEventController(repository.Object)
            {
                ControllerContext = controllerContext.Object
            };
            var result = (RegisterEventModel)controller.Register(1).ViewData.Model;
            Assert.AreEqual(1, result.CinemaId);

        }
        //[TestMethod]
        //public void RegisterEventPostTest()
        //{
        //    Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
        //    Mock<IPrincipal> principal = new Mock<IPrincipal>();
        //    Mock<IMainRepository> repository = new Mock<IMainRepository>();
        //    repository.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(
        //        new AppUser
        //        {
        //            Email = "know.nothing@gmail.com",
        //            Id = "userI",
        //            FirstName = "John",
        //            LastName = "Snow",
        //            IsBanned = false,
        //            UserName = "John"
        //        }
        //        );
        //    Cinema cinema1 = new Cinema
        //    {
        //        Name = "Event Hall KINO",
        //        Description = "Club'n'Movie",
        //        Address = "Nekrasova 22",
        //        Rows = 50,
        //        Seats = 30
        //    };
        //    repository.Setup(x => x.GetCinemaById(1)).Returns(
        //        cinema1
        //        );
           
        //    Movie movie1 = new Movie();
        //    AppUser user1 = new AppUser { UserName = "user1" };
        //    Event event1 = new Event
        //    {
        //        Cinema = cinema1,
        //        Movie = movie1,
        //        IsApproved = false,
        //        Price = 50,
        //        Author = user1.UserName,
        //        Name = "Relax"
        //    };

        //    RegisterEventModel model = new RegisterEventModel
        //    {
        //        CinemaId = 1
        //    };
        //    RegisterEventController controller = new RegisterEventController(repository.Object)
        //    {
        //        ControllerContext = controllerContext.Object
        //    };
        //    var result = (RedirectToRouteResult)controller.Register(model);
        //    Assert.AreEqual(1,1);
        
    }
}
