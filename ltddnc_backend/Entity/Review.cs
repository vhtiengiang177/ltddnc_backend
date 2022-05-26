﻿using System;

namespace ltddnc_backend.Entity
{
    public class Review
    {
        public int Id { get; set;}
        public int IdProduct { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; } = 5;
        public DateTime Date { get; set; }
        public string? Image { get; set; }

        public  User User { get; set; }
        public  Product Product { get; set; }
    }
}
