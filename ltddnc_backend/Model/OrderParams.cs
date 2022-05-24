using ltddnc_backend.Entity;
using System.Collections.Generic;

namespace ltddnc_backend.Model
{
    public class OrderParams
    {
        //public string Name { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Address { get; set; }
        //public int IdUser { get; set; }
        public Order Order { get; set; }
        public List<OrderDetail> ListOrderDetail { get; set; }
    }
}
