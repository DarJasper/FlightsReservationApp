using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsReservationApp.Models
{
    public class Seats
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "row")]
        public int Row { get; set; }

        [JsonProperty(PropertyName = "column")]
        public char Column { get; set; }

        [JsonProperty(PropertyName = "available")]
        public bool Available { get; set; }

        public string Seat
        {
            get
            {
                return Row.ToString() + Column;
            }
        }
    }
}
