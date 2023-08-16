using MM.CAAM.Gestion.DTO.DTOs;
using System.Security.Principal;

namespace MM.CAAM.Admin.Web
{
    public static class PrincipalExtensions
    {
        public static CustomIdentity GetMyIdentity(this IPrincipal principal)
        {
            return principal.Identity as CustomIdentity;
        }
    }
    public class UsuarioPrincipal
    {
    }


    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(string _userName)
        {
            userName = _userName;
            isAuthenticated = true;
        }

        public string AuthenticationType { get => "CustomAuthentication"; }

        private bool isAuthenticated;
        public bool IsAuthenticated { get => isAuthenticated; private set => isAuthenticated = value; }

        private string userName;
        public string Name { get => userName; set => userName = value; }

        private string displayName;
        public string DisplayName { get => displayName; set => displayName = value; }

        private UsuarioProfile usuarioProfile;
        public UsuarioProfile UsuarioProfile { get => usuarioProfile; set => usuarioProfile = value; }

        //private Roles role;
        //public Roles Role { get => role; set => role = value; }
    }

    public class UsuarioProfile
    {
        public UsuarioDTO Usuario { get; set; }
    }
}
