﻿using System;

namespace ltddnc_backend.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; } = 0;
        public double UnitPrice { get; set; }
        public int State { get; set; } = 1;
        public int? IdCategory { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category Category { get; set; }
        public string? Image { get; set; }
    }
}
