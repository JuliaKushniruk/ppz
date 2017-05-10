using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class BannedUsersModel
    {
        public IEnumerable<AppUser> BannedUsers { get; set; }
    }
}