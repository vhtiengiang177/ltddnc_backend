using ltddnc_backend.Entity;
using System;

namespace ltddnc_backend.Model
{
    public class OrderUI
    {
        public int Id { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalProductPrice { get; set; }
        public int State { get; set; } = 1; // 1: Dang xu ly, 2: Dang giao, 3: Da giao, 4: Da huy
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public int IdUser { get; set; }
        public OrderDetailUI FirstOrderDetail { get; set; }
    }
}
