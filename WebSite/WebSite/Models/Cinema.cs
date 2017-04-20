using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class Cinema
    {
        [Key]
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Rows { get; set; }
        public int Seats { get; set; }
    }
}