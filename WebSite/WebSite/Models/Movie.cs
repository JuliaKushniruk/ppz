using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebSite.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Cast { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Event> Events { get; set; }

    }
}