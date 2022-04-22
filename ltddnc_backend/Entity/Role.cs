using System.Collections.Generic;

namespace ltddnc_backend.Entity
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; } = 1;
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
