using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    // Models/User.cs
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Navigation property
        public ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();
    }

}
