using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class TicketDetailsDTO
    {
        public string MovieName { get; set; }
        public int ScreenNumber { get; set; }
        public int NoOfSeatsBooked { get; set; }
        public int PerPersonPrice { get; set; }
        public int TotalAmount { get; set; }
        public DateOnly ShowDate { get; set; }
        public TimeOnly ShowTime { get; set; }
        
    }
}
