using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightsApp.Models
{
    public class Flight
    {
        [Key]
        [Column("FlightsId")]
        public Guid FlightId { get; set; }
        [Required]
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        //navigatie property
        [Column("AirportId_departure")]
        public Airport DepartureAirport { get; set; }
        [Column("AirportId_arrival")]
        public Airport ArrivalAirport { get; set; }

        //navigatie property
        public Airplane Airplane { get; set; }

    }
}
