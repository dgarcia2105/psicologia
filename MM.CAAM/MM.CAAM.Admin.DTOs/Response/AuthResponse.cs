
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MM.CAAM.Admin.DTOs.Response
{
    public class AuthResponse
    {
        public long UsuarioId { get; set; }
        public string BearerToken { get; set; }
        public string RefreshToken { get; set; }
        public string FCMToken { get; set; }
    }
}
