using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class SearchModel
    {
        public string Name { get; set; }
        public IEnumerable<Cinema> CinemasFound { get; set; }
    }
}