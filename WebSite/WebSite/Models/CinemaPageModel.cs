using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class CinemaPageModel
    {
        public IEnumerable<Event> Events { get; set; }
        public Cinema CurrentCinema { get; set; }
    }
}