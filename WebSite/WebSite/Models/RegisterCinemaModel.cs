using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebSite.Models
{
    public class RegisterCinemaModel
    {
        public Cinema Cinema {get; set;}
        public string CurrentUserId { get; set; }
    }
}