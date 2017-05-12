using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebSite.Models
{
    public class CinemaPageModel
    {
        public IEnumerable<Event> Events { get; set; }
        public Cinema CurrentCinema { get; set; }
        public bool IsModerator { get; set; }
    }
}