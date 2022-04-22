namespace ltddnc_backend.Model
{
    public class UserAccountParams
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int State { get; set; } = 1; // 0: Delete, 1: Active, 2: Block
        public int IdRole { get; set; } //0: Admin, 2:Client
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
