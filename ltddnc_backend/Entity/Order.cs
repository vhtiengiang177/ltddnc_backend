﻿using System.Collections.Generic;

namespace ltddnc_backend.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalProductPrice { get; set; }
        public double TotalAmount { get; set; }
        public int State { get; set; } = 1;
        public double FeeDelivery { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}