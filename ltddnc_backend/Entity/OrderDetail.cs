namespace ltddnc_backend.Entity
{
    public class OrderDetail
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
