using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsReservationApp.Models
{
    public class Airplanes
    {
        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "seats")]
        public string Seats { get; set; }

        [JsonProperty(PropertyName = "rows")]
        public string Rows { get; set; }

        [JsonProperty(PropertyName = "columns")]
        public string Columns { get; set; }
    }
}
