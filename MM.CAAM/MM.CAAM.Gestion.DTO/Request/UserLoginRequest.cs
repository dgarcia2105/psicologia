

namespace MM.CAAM.Gestion.DTO.DTOs.Request
{
    public class UserLoginRequest
    {
        public string? Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? FcmToken { get; set; }
    }
}
