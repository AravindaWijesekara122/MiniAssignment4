using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class ShowDTO
    {
        public string MovieName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Timings { get; set; }
        public int NoOfSeats { get; set; }
        public int PerPersonPrice { get; set; }
        public int ScreenNumber { get; set; }
    }
}
