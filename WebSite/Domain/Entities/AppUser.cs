using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities
{
    public class AppUser : IdentityUser
    {  
        public virtual ICollection<Event> Events { get; set; }
        public bool IsBanned { get; set; }
    }
}