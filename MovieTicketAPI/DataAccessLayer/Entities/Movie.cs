using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<Show>? Shows { get; set; } = new List<Show>();
    }
}
