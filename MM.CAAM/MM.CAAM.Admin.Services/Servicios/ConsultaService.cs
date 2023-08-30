using System.Collections.Generic;
using System;
using System.Net;
using System.Threading.Tasks;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Request;
using MM.CAAM.Gestion.DTO.DTOs.Response;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Gestion.DTO.Objects;
using MM.CAAM.Gestion.Models.Entidades;

namespace MM.CAAM.Admin.Services.Servicios
{
    public interface IConsultaService
    { 
        Task<List<ConsultaDTO>> ObtenerConsultas();
        Task<List<ConsultaDTO>> ObtenerConsultasPorUsuario(int usuarioId);
        Task<ConsultaDTO> ObtenerConsultasPorUsuarioYConsultaId(int usuarioId, int consultaId);
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

        public async Task<List<ConsultaDTO>> ObtenerConsultas()
        {
            var endPoint = $"/api/usuarios/0/consultas/ObtenerConsultas";

            var result = await RESTService.Get<List<ConsultaDTO>>(endPoint, "");

            if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            return result.Data;
        }

        public async Task<List<ConsultaDTO>> ObtenerConsultasPorUsuario(int usuarioId)
        {
            var endPoint = $"/api/usuarios/{usuarioId}/consultas";

            var result = await RESTService.Get<List<ConsultaDTO>>(endPoint, "");

            if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            return result.Data;
        }
        public async Task<ConsultaDTO> ObtenerConsultasPorUsuarioYConsultaId(int usuarioId,int consultaId)
        {
            var endPoint = $"/api/usuarios/{usuarioId}/consultas/{consultaId}";

            var result = await RESTService.Get<ConsultaDTO>(endPoint, "");

            if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            return result.Data;
        }
    }

}
