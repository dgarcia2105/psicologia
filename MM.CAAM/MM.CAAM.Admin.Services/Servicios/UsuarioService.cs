using MM.CAAM.Admin.DTOs;
using MM.CAAM.Admin.DTOs.Objects;
using MM.CAAM.Admin.DTOs.Request;
using MM.CAAM.Admin.DTOs.Response;
using MM.CAAM.Admin.DTOs.Test;
using MM.CAAM.Admin.Services.Exceptions;
using System.Net;
using System.Threading.Tasks;

namespace MM.CAAM.Admin.Services.Servicios.Test
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> LoginApi(UsuarioDTO dto);
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IRESTService RESTService;
        public UsuarioService(IRESTService restService) 
        {
            RESTService = restService;
        }

        public async Task<UsuarioDTO> LoginApi(UsuarioDTO dto)
        {
            var endPoint = $"/api/usuario/login/";

            var payload = new UserLoginRequest
            {
                Username = dto.Usuario,
                Password = dto.Password
            };

            var result = await RESTService.Post<AuthResponse>(endPoint, payload);

            if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            var authResponse = result.Data;

            ////Query para obtener usuario
            //var dataTable = ManagerService.ManagerI.queryObtenerDT(Querys.QueryUsuario.UsuarioCompleto(pUsuarioId: authResponse.UsuarioId));
            //var usuario = UsuarioMap.ToDto(dataTable.Rows[0]);

            //usuario.BearerToken = authResponse.BearerToken;

            //return usuario;

            return null;
        }
    }

}
