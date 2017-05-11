//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using WebSite.Models;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.AspNet.Identity;
//using Domain.Concrete;
//using Domain.Entities;
//using Domain.Abstract;

//namespace WebSite.Helpers
//{
//    public interface ICinemaService
//    {
//        void AddToRole(string userId, string role);
//    }

//    public class CinemaService: ICinemaService
//    {
//        public void AddToRole(string userId, string role)
//        {
//            UserManager.AddToRoleAsync(userId, role);

//        }
//        //private AppUserManager UserManager
//        //{
//        //    get
//        //    {
//        //        //return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
//        //    }
//        //}
//    }
//}

