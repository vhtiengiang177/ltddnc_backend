namespace ltddnc_backend.Model
{
    public class OrderDetailUI
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string ImageProduct { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
