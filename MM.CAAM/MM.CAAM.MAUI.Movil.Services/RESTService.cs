using Microsoft.VisualBasic;
using MM.CAAM.MAUI.Movil.DTOs;
using MM.CAAM.MAUI.Movil.DTOs.Request;
using MM.CAAM.MAUI.Movil.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MM.CAAM.MAUI.Movil.Services
{
    public interface IRESTService
    {
         
    }
    public class RESTService : IRESTService
    {

        public RESTService() 
        { 
        
        }

        private readonly HttpClient client = new HttpClient();

        private static int _refreshTokenEntered = 0; 
        private const string REFRESH_TOKEN_URL = "/api/usuario/refresh_token";
        private const string AUTH_URL = "/api/usuario/login";
        private const string FILES_UPLOAD_URL = "/api/files/upload";
        private const string CREATE_PLANTILLA_CENTRAL = "/api/documento/obtener_plantilla_file";

    }
}
