
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MM.CAAM.Admin.DTOs.Request
{
    public class UserLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FcmToken { get; set; }
    }
}
