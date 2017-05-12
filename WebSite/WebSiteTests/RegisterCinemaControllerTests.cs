using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using WebSite.Controllers;
using WebSite.Models;
using System.Web.Mvc;
using System.Security.Principal;

namespace WebSiteTests
{
    [TestClass]
    public class RegisterCinemaControllerTests
    {
        [TestMethod]
        public void RegisterCinemaGetTest()
        {
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            Mock<IPrincipal> principal = new Mock<IPrincipal>();
            principal.SetupGet(x => x.Identity.Name).Returns("user");
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);

            Mock<IMainRepository> repository = new Mock<IMainRepository>();
            repository.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(
                new AppUser
                {
                    Email = "know.nothing@gmail.com",
                    Id = "userI",
                    FirstName = "John",
                    LastName = "Snow",
                    IsBanned = false,
                    UserName = "John"
                }
                );
            RegisterCinemaController controller = new RegisterCinemaController(repository.Object)
            {
                ControllerContext = controllerContext.Object
            };
            var result = (RegisterCinemaModel)controller.Register().ViewData.Model;
            Assert.AreEqual("userI", result.CurrentUser.Id);
        }
    }
}
