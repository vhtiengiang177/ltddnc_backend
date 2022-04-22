using System.Collections.Generic;

namespace ltddnc_backend.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; } = 1;

        public virtual ICollection<Product> Products { get; set; }
    }
}
