namespace CollageWebAPI.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string Password { get; set; } = null!;

        public string? Role { get; set; }
    }
}
