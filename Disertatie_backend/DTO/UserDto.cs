namespace Disertatie_backend.DTO
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string PhotoUrl { get; set; }
        public string KnownAs { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool IsSubscribed { get; set; }
        public bool HasDarkMode { get; set; }
    }
}
