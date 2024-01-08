using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class TicketBookingRequest
    {
        public DateOnly ShowDate { get; set; }
        public TimeOnly ShowTime { get; set; }
        public int NoOfSeatBooked { get; set; }
        public int UserId { get; set; }
        public int ShowId { get; set; }
    }
}
