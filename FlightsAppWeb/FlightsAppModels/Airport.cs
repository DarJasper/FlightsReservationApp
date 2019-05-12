using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightsApp.Models
{
    public class Airport
    {
        [Key]
        public string AirportName { get; set; }
        [Required]
        public string AirportCity { get; set; }

        [InverseProperty("DepartureAirport")]
        public ICollection<Flight> DepartingFlights { get; set; }
        [InverseProperty("ArrivalAirport")]
        public ICollection<Flight> ArrivingFlights { get; set; }
    }
}
