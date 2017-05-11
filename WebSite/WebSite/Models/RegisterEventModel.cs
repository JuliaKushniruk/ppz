using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebSite.Models
{
    public class RegisterEventModel
    {
        public Movie Movie { get; set; }
        public int CinemaId { get; set; }
        public double Price { get; set; }
    }
}