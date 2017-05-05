using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebSite.Models
{
    public class AppUser : IdentityUser
    {
        // additional properties will go here   
        public virtual ICollection<Event> Events { get; set; }
    }
}