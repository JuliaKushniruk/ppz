using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class Movie
    {
        public string Name;
        public int Year;
        public string Genre;
        public string Author;
        public List<string> Cast;
        public string Description;
    }
}