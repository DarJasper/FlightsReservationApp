using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsReservationApp.Models
{
    public class Tickets
    {
        public Guid SeatId { get; set; }
        public Guid FlightId { get; set; }
    }
}
