using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightsApp.Models
{
    public class Airplane
    {
        // Id, Model, Seats, Rows, Columns
        [Key]
        public Guid AirplaneId { get; set; }
        [Required]
        public string Model { get; set; }
        public int Seats { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public ICollection<Seat> SeatsC { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
