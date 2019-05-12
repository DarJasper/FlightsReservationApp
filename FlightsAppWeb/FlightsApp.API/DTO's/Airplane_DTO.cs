using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsApp.API.DTO_s
{
    public class Airplane_DTO
    {
        public string Model { get; set; }
        public int Seats { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
    }
}
