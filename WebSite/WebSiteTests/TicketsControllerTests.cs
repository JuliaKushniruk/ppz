using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Security.Principal;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using WebSite.Controllers;
using System.Collections.Generic;
using WebSite.Models;
using System.Linq;

namespace WebSiteTests
{
    [TestClass]
    public class TicketsControllerTests
    {
        [TestMethod]
        public void ViewTicketsTest()
        {
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            Mock<IPrincipal> principal = new Mock<IPrincipal>();
            principal.SetupGet(x => x.Identity.Name).Returns("user");
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);

            Mock<IMainRepository> repository = new Mock<IMainRepository>();
            AppUser user = new AppUser
            {
                Email = "know.nothing@gmail.com",
                Id = "userI",
                FirstName = "John",
                LastName = "Snow",
                IsBanned = false,
                UserName = "John"
            };
            Event event1 = new Event();
            Ticket ticket1 = new Ticket
            {
                Owner = user,
                Row = 30,
                Seat = 20,
                Event = event1
            };
            Ticket ticket2 = new Ticket
            {
                Owner = user,
                Row = 20,
                Seat = 30,
                Event = event1
            };
            repository.Setup(x => x.GetTicketsByUserId(It.IsAny<string>())).Returns(
                new List<Ticket>
                {
                    ticket1,ticket2
                }
                );
            TicketsController controller = new TicketsController(repository.Object)
            {
                ControllerContext = controllerContext.Object
            };
            var result = (ViewTicketsModel)controller.ViewTickets().ViewData.Model;
            Assert.AreEqual(user,result.Tickets.ToList()[0].Owner);
            Assert.AreEqual(user, result.Tickets.ToList()[1].Owner);
            Assert.AreEqual(event1, result.Tickets.ToList()[0].Event);
            Assert.AreEqual(event1, result.Tickets.ToList()[1].Event);
            Assert.AreEqual(30, result.Tickets.ToList()[0].Row);
            Assert.AreEqual(20, result.Tickets.ToList()[1].Row);
            Assert.AreEqual(20, result.Tickets.ToList()[0].Seat);
            Assert.AreEqual(30, result.Tickets.ToList()[1].Seat);
        }
    }
}
