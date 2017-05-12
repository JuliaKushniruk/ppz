using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebSite.Models
{
    public class SearchEventModel
    {
        public string Name { get; set; }
        public IEnumerable<Event> EventsFound { get; set; }
    }
}