using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsReservationApp.Models
{
    public class Flights
    {
        [JsonProperty(PropertyName = "flightNumber")]
        public string FlightNumber { get; set; }

        [JsonProperty(PropertyName = "departureTime")]
        public DateTime DepartureTime { get; set; }

        [JsonProperty(PropertyName = "arrivalTime")]
        public DateTime ArrivalTime { get; set; }

        [JsonProperty(PropertyName = "airportDeparture")]
        public Airports DepartureAirport { get; set; }

        [JsonProperty(PropertyName = "airportArrival")]
        public Airports ArrivalAirport { get; set; }

        [JsonProperty(PropertyName = "airplane")]
        public Airports Airplane { get; set; }
    }
}
