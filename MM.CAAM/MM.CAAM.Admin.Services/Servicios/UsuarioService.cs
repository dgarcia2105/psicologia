using System.Collections.Generic;
using System;
using System.Net;
using System.Threading.Tasks;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Request;
using MM.CAAM.Gestion.DTO.DTOs.Response;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Gestion.DTO.Objects;

namespace MM.CAAM.Admin.Services.Servicios
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> LoginApi(UsuarioDTO dto);
        Task<List<UsuarioDTO>> ObtenerListaUsuarios();
        Task<CatalogoDTO> ObtenerCatalogos();
        Task<UsuarioDTO> ObtenerUsuario(int usuarioId);
        Task<UsuarioDTO> InsertUsuario(UsuarioCreacionDTO dto);
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
            var endPoint = $"/api/usuarios/login/";

            var payload = new UserLoginRequest
            {
                Username    = dto.Correo,
                Email       = dto.Correo,
                Password    = dto.Password
            };

            var result = await RESTService.Post<AuthResponse>(endPoint, payload);

            if (result == null)
                throw new ValidationException("Error de conexión");
            else if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            var authResponse = result.Data;

            var usuarioId = authResponse.UsuarioId;

            var endPointGetUsuario = $"/api/usuarios/{usuarioId}";

            var resultUsuarioDto = await RESTService.Get<UsuarioDTO>(endPointGetUsuario, "");

            if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            var usuarioDto = resultUsuarioDto.Data;

            usuarioDto.BearerToken = authResponse.BearerToken;

            return usuarioDto;
        }

        public async Task<UsuarioDTO> InsertUsuario(UsuarioCreacionDTO payload)
        {

            var endPoint = $"/api/usuarios";

            var result = await RESTService.Post<UsuarioDTO>(endPoint, payload, "");

            if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            return result.Data;
        }

        public async Task<List<UsuarioDTO>> ObtenerListaUsuarios()
        {
            var endPoint = $"/api/usuarios";

            var result = await RESTService.Get<List<UsuarioDTO>>(endPoint, "");

            if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            return result.Data;
        }
        public async Task<CatalogoDTO> ObtenerCatalogos()
        {
            var endPoint = $"/api/usuarios/obtener_catalogos";

            var result = await RESTService.Get<CatalogoDTO>(endPoint, "");

            if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            return result.Data;
        }

        public async Task<UsuarioDTO> ObtenerUsuario(int usuarioId)
        {
            var endPoint = $"/api/usuarios/{usuarioId}";

            var result = await RESTService.Get<UsuarioDTO>(endPoint, "");

            if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            return result.Data;
        }
    }

}
