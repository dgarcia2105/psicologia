using MM.CAAM.MAUI.Movil.DTOs;
using MM.CAAM.MAUI.Movil.DTOs.Request;
using MM.CAAM.MAUI.Movil.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.CAAM.MAUI.Movil.Services
{
    public interface IRESTService
    {
        string BearerToken { get; }
        string RefreshToken { get; }


        Task<AuthResponse> AuthWithRefreshTokenAsync();
        Task<AuthResponse> AuthWithCredentialsAsync(string username, string password);

        Task<TResponse> ExecuteWithRetryAsync<TResponse>(Func<string, object, Task<TResponse>> method, string endpoint, object parameters);
        Task<Result<TObject>> Get<TObject>(string endpoint, object parameters);
        Task<Result<TObject>> Post<TObject>(string endpoint, object payload);
        Task<Result<TObject>> PostAndUploadFile<TObject>(string endpoint, object payload, string pathFileUpload);
        Task<Stream> GetStreamDocumento<TObject>(string endpoint, object payload);
        Task<Stream> GetPdfSolicitudNotificacion<TObject>(FileManagerRequest data, string filePath);
        Task<Result<DocumentoFirmadoResponse>> FirmarDocumentoFIREC<TObject>(FirmarDocumentoRequest payloadData, string pathArchivoFirmar, string pathFileKey, string pathFileCertificado);

    }
    public class RESTService : IRESTService
    {

        public RESTService() 
        { 
        
        }

        private readonly HttpClient client = new HttpClient();

        private static int _refreshTokenEntered = 0;
        //public string BearerToken => Preferences.Get("BearerToken", string.Empty);
        //public string RefreshToken => Preferences.Get("RefreshToken", string.Empty);
        private const string REFRESH_TOKEN_URL = "/api/usuario/refresh_token";
        private const string AUTH_URL = "/api/usuario/login";
        private const string FILES_UPLOAD_URL = "/api/files/upload";
        private const string CREATE_PLANTILLA_CENTRAL = "/api/documento/obtener_plantilla_file"; 
    }
}
