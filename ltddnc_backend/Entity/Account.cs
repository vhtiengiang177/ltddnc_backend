namespace ltddnc_backend.Entity
{
    public class Account
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int State { get; set; } = 1; // 0: Delete, 1: Active, 2: Block
        public int IdRole { get; set; } // 1: Admin, 2:Client
        public Role Role { get; set; } 
        public User User { get; set; } 
    }
}
