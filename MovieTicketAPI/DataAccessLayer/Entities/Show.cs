using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Show
    {
        public int ShowId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Timings { get; set; }
        public int NoOfSeats { get; set; }
        public int Price { get; set; }
        public int ScreenNumber { get; set; }

        // Foreign Keys
        public int? MovieId { get; set; }

        // Navigation properties
        public Movie? Movie { get; set; }
        public ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();
    }
}
