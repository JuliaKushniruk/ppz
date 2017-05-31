using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebSite.Models
{
    public class EventLikedModel
    {
        public string Name { get; set; }
        public int EventId { get; set; }
        public string Cinema { get; set; }
        public int CinemaID { get; set; }
        public string Film { get; set; }
        public bool? IsApproved { get; set; }
        public double Price { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string Author { get; set; }
        public bool IsLiked { get; set; }
        public int LikesAmount { get; set; }

        public int MovieId { get; set; }
    }
}