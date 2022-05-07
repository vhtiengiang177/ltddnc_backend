using System.Collections.Generic;

namespace ltddnc_backend.Entity
{
    public class User
    {
        public int IdAccount { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
