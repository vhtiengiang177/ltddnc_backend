using System;
using System.Collections.Generic;

namespace ltddnc_backend.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalProductPrice { get; set; }
        public int State { get; set; } = 1; // 1: Dang xu ly, 2: Dang giao, 3: Da giao, 4: Da huy
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public int IdUser { get; set; }
        //public int ReviewState { get; set; } = 0;
        public User User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
