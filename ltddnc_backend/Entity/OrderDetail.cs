namespace ltddnc_backend.Entity
{
    public class OrderDetail
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        //public int ReviewState { get; set; } = 0; //0: chưa review 1: đã review
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
