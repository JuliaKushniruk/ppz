using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Infrastructure;

namespace WebSite.Controllers
{
    public class ContextSingleton
    {
        public CinemasSiteContext Context;

        private static ContextSingleton instance = null;

        public static ContextSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContextSingleton();
                    instance.Context = new CinemasSiteContext();
                }
                return instance;
            }
        }
    }
}