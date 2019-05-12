using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightsApp.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }
        [Required]
        public int Row { get; set; }
        public string Column { get; set; }
        public bool Available { get; set; }

        public Airplane Airplane { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
