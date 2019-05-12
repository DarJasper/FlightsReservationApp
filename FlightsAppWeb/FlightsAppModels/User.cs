using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightsApp.Models
{
    public class User
    {

        // Id, Email, Password

        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
