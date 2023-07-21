using MM.CAAM.Admin.DTOs;
using MM.CAAM.Admin.DTOs.Objects;
using MM.CAAM.Admin.DTOs.Request;
using MM.CAAM.Admin.DTOs.Response;
using MM.CAAM.Admin.DTOs.Test;
using MM.CAAM.Admin.Services.Exceptions;
using System.Collections.Generic;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MM.CAAM.Admin.Services.Servicios.Test
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> LoginApi(UsuarioDto dto);
        Task<List<string>> InsertUsuario(UsuarioCreacionDTO dto);
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IRESTService RESTService;
        public UsuarioService(IRESTService restService) 
        {
            RESTService = restService;
        }

        public async Task<UsuarioDto> LoginApi(UsuarioDto dto)
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

        public async Task<List<string>> InsertUsuario(UsuarioCreacionDTO payload)
        {

            var endPoint = $"/api/usuarios";

            var result = await RESTService.Post<List<string>>(endPoint, payload, "");

            if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            return result.Data;

            //return result;

            //var pParametros = new Dictionary<string, object>
            //{
            //    { nameof(usuarios.usuario), dto.Usuario },
            //    { nameof(usuarios.empno), dto.Empno }
            //};

            //var pParametrosNoEmpleado = new Dictionary<string, object>
            //{
            //    { nameof(usuarios.empno), dto.Empno }
            //};

            //var entityRepeat = ManagerService.ManagerI.obtenerRegistro<usuarios>(pParametros, pSoloActivos: false);
            //var entityRepeatNoEmpleado = ManagerService.ManagerI.obtenerRegistro<usuarios>(pParametrosNoEmpleado, pSoloActivos: false);

            //if (entityRepeat.usuario_id > 0 && entityRepeat.usuario.ToLower().Equals(dto.Usuario.ToLower()))
            //    throw new ValidationException("El usuario ya existe en nuestra app.");

            //Int32.TryParse(dto.Empno, out int empnoDto);
            //Int32.TryParse(entityRepeatNoEmpleado.empno, out int empnoEntity);


            //if (empnoDto <= 0)
            //    throw new ValidationException("No. de empleado no valido");

            //if (empnoDto == empnoEntity)
            //    throw new ValidationException("El no. de empleado ya existe en nuestra app.");

            //var saltNew = Com.GenerateSalt();
            //var entity = new usuarios
            //{
            //    rol_id = dto.RolId,
            //    central_id = dto.CentralId,
            //    usuario = dto.Usuario,
            //    nombres = dto.Nombres,
            //    apellidos = dto.Apellidos,
            //    correo = dto.CorreoElectronico,
            //    salt = saltNew,
            //    password = Com.HashPassword(dto.Password, saltNew),
            //    activo = dto.Activo,
            //    empno = dto.Empno,
            //    genero = dto.Genero,
            //    curp = dto.CURP,
            //};
            //if (!string.IsNullOrWhiteSpace(dto.PerfilNombreArchivo))
            //    entity.perfil_nombre_archivo = dto.PerfilNombreArchivo;

            //entity.usuario_id = ManagerService.ManagerI.agregarRegistro(entity);
        }
    }

}
