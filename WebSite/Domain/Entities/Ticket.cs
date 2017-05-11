using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entities
{
    public class Ticket
    {
        public Event Event { get; set; }
        public AppUser Owner { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
    }
}