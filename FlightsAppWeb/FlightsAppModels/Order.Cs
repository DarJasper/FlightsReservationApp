using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightsApp.Models
{
    public class Order
    {
        // Id, Price, #Tickets, By who
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int Price { get; set; }
        public DateTime DateOfEntry { get; set; } = DateTime.Now;

        // 1 - Many relation
        public User User { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
