using FlightsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsApp.API.DTO_s
{
    public class Flights_DTO
    {
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public Airports_DTO DepartureAirport { get; set; }
        public Airports_DTO ArrivalAirport { get; set; }

        public Airplane_DTO Airplane { get; set; }
    }
}
