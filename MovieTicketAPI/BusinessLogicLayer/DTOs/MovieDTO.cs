﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }

    }
}
