﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int Stock { get; set; }
        public string Author { get; set; }
    }
}
