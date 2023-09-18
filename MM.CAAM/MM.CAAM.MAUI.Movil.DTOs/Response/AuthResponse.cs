using System.Text.Json.Serialization; 

namespace MM.CAAM.MAUI.Movil.DTOs.Response
{
    public class AuthResponse
    {
        public int UsuarioId { get; set; }
        public string BearerToken { get; set; }
        public string RefreshToken { get; set; }
        public string FCMToken { get; set; }

        [JsonIgnore]
        public bool Success { get; set; }
    }
}
