namespace ltddnc_backend.Entity
{
    public class Favorite
    {
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public virtual User User { get; set; }
    }
}
