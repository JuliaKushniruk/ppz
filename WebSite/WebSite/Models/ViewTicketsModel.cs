using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebSite.Models
{
    public class ViewTicketsModel
    {
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}