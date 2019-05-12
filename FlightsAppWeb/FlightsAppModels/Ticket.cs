using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightsApp.Models
{
    public class Ticket
    {
        // Id, From which order, which seats, which flight

        [Key]
        public int TicketId { get; set; }

        [Required]
        public Order Order { get; set; }
        public Seat Seat { get; set; }
        public Flight Flight { get; set; }
    }
}
