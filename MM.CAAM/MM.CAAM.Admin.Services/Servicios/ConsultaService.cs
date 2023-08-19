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
    public interface IConsultaService
    { 
        Task<List<UsuarioDTO>> ObtenerListaUsuarios();
        Task<UsuarioDTO> ObtenerUsuario(int usuarioId);
        Task<UsuarioDTO> CrearConsulta(int UsuarioId, ConsultaCreacionDTO payload);
    }

    public class ConsultaService : IConsultaService
    {
        private readonly IRESTService RESTService;
        public ConsultaService(IRESTService restService) 
        {
            RESTService = restService;
        }
          
        public async Task<UsuarioDTO> CrearConsulta(int UsuarioId, ConsultaCreacionDTO payload)
        {

            var endPoint = $"/api/usuarios/{UsuarioId}/consultas";

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
