using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebSite.Models
{
    public class AppUser : IdentityUser
    {  
        public virtual ICollection<Event> Events { get; set; }
    }
}