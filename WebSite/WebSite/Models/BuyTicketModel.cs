using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class BuyTicketModel
    {
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public double EventPrice { get; set; }
        public string MovieName { get; set; }
        public string OwnerId { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
    }
}