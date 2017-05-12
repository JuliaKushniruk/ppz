using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
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

        public ICollection<Event> Events { get; set; }

        public virtual AppUser Moderator { get; set; }

        //public int AAA { get; set; }
    }
}