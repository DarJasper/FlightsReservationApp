using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsReservationApp.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
