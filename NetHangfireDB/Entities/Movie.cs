﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHangfireDB.Entities
{
    public class Movie
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string ReleaseYear { get; set; } = string.Empty;
        public string Poster { get; set; } = string.Empty; 
    }
}
