using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsReservationApp.Models
{
    public class City
    {
        [JsonProperty(PropertyName = "photos")]
        public Photo[] Photos { get; set; }

        public class Photo
        {
            [JsonProperty(PropertyName = "image")]
            public Image Image { get; set; }
        }

        public class Image
        {
            [JsonProperty(PropertyName = "mobile")]
            public string Mobile { get; set; }
        }

    }
}
