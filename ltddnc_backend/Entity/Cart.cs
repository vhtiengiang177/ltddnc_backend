namespace ltddnc_backend.Entity
{
    public class Cart
    {
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public virtual User User { get; set; }
    }
}
