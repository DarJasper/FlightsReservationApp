using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsReservationApp.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public List<Tickets> Tickets { get; set; }
    }
}
