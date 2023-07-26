
namespace MM.CAAM.Gestion.DTO.DTOs.Response
{
    public class AuthResponse
    {
        public long UsuarioId { get; set; }
        public string BearerToken { get; set; }
        public string RefreshToken { get; set; }
        public string FCMToken { get; set; }
    }
}
