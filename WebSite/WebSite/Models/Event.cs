﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebSite.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual Movie Movie { get; set; }
        public string Author { get; set; }
        public bool IsApproved { get; set; }
        public double Price { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }

        
    }
}