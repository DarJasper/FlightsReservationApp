using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FlightsReservationApp.Models
{
    public class Flights
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

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

        [JsonProperty(PropertyName = "seats")]
        public List<Seats> Seats { get; set; }

        public string Route
        {
            get
            {
                return (DepartureAirport.Name + " -> " + ArrivalAirport.Name);
            }
        }

        public string Date
        {
            get
            {
                return DepartureTime.ToString("dd/MM/yyyy");
            }
        }

        public string Time
        {
            get
            {
                return DepartureTime.ToString("hh:mm");
            }
        }

        public string AMPM
        {
            get
            {
                return DepartureTime.ToString("tt", CultureInfo.InvariantCulture);
            }
        }
    }
}
