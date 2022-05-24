using ltddnc_backend.Entity;

namespace ltddnc_backend.Model
{
    public class CartUI
    {
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
