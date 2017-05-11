using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.Entity;
using Domain.Entities;

namespace WebSite.Models
{
    public class UserPageModel
    {
        public AppUser User {get; set;}
        public IEnumerable<Cinema> ModeratedCinemas { get; set; }
        public string CurrentUserId { get; set; }
        public bool IsAdministratorLogged { get; set; }
    }
}