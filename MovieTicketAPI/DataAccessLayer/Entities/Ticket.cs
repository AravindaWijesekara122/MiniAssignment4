using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateOnly ShowDate { get; set; }
        public TimeOnly ShowTime { get; set; }
        public int NoOfSeatBooked { get; set; }
        public int TotalAmount { get; set; }

        // Foreign Keys
        public int? UserId { get; set; }
        public int? ShowId { get; set; }

        // Navigation properties
        public User? User { get; set; }
        public Show? Show { get; set; }
        // Other ticket properties
    }
}
