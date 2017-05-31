using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using WebSite.Controllers;
using WebSite.Models;
using System.Web.Mvc;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;

namespace WebSiteTests
{
    [TestClass]
    public class BannedUsersControllerTests
    {
        [TestMethod]
        public void ViewBannedUsersTest()
        {
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            Mock<IPrincipal> principal = new Mock<IPrincipal>();
            principal.SetupGet(x => x.Identity.Name).Returns("user");
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);

            AppUser user1 = new AppUser
            {
                Email = "know.nothing@gmail.com",
                Id = "user1",
                FirstName = "John",
                LastName = "Snow",
                IsBanned = false,
                UserName = "John"
            };
            AppUser user2 = new AppUser
            {
                Email = "mail@gmail.com",
                Id = "user2",
                FirstName = "Ned",
                LastName = "Stark",
                IsBanned = true,
                UserName = "Ned"
            };

            Mock<IMainRepository> repository = new Mock<IMainRepository>();
            repository.Setup(x => x.GetUsers()).Returns(new List<AppUser>
            {
                user1, user2 }
            );
            

            BannedUsersController controller = new BannedUsersController(repository.Object)
            {
                ControllerContext = controllerContext.Object
            };

            var result = (BannedUsersModel)controller.ViewBannedUsers().ViewData.Model;
            Assert.AreEqual("user2", result.BannedUsers.ToList()[0].Id);
            Assert.AreEqual("Ned", result.BannedUsers.ToList()[0].FirstName);
            Assert.AreEqual("Stark", result.BannedUsers.ToList()[0].LastName);
            Assert.AreEqual(true, result.BannedUsers.ToList()[0].IsBanned);
            Assert.AreEqual("Ned", result.BannedUsers.ToList()[0].UserName);
        }

        [TestMethod]
        public void UnbanTest()
        {
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            Mock<IPrincipal> principal = new Mock<IPrincipal>();
            principal.SetupGet(x => x.Identity.Name).Returns("user");
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);

            AppUser user = new AppUser
            {
                Email = "know.nothing@gmail.com",
                Id = "user",
                FirstName = "John",
                LastName = "Snow",
                IsBanned = true,
                UserName = "John"
            };
           

            Mock<IMainRepository> repository = new Mock<IMainRepository>();
            repository.Setup(x => x.GetUserById("user")).Returns(
            
                user
            );


            BannedUsersController controller = new BannedUsersController(repository.Object)
            {
                ControllerContext = controllerContext.Object
            };

            var result = (RedirectToRouteResult)controller.Unban("user");
            repository.Verify(x => x.UpdateUser(user), Times.Once);
          
            Assert.AreEqual("ViewBannedUsers", result.RouteValues["action"]);
        }
    }
}
