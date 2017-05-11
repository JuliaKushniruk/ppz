using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public Event Event { get; set; }
        public AppUser Owner { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
    }
}