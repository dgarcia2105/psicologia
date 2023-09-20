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

        public async Task<TResponse> ExecuteWithRetryAsync<TResponse>(Func<string, object, Task<TResponse>> webApiCallMethod, string endpoint, object parameters)
        {
            var tryForceRefreshToken = false;
            var attemptsCounter = 1;
            while (true)
            {
                Debug.WriteLine("Loop req");
                if (tryForceRefreshToken)
                {
                    var success = await TryAuthWithRefreshTokenAsync();
                    Debug.WriteLine($"RefreshToken result: {success}");

                    if (!success)
                        MessagingCenter.Send(new ExecuteActionMessage { ExecuteAction = true }, Constants.LogoutMessage);
                }
                try
                {
                    attemptsCounter++;

                    Debug.WriteLine("Send request");
                    var policyResult = await Policy<TResponse>
                                                .Handle<TimeoutRejectedException>()
                                                .WaitAndRetryAsync(2, retryNumber => TimeSpan.FromSeconds(3))
                                                .ExecuteAndCaptureAsync(async () =>
                                                    await webApiCallMethod.Invoke(endpoint, parameters)
                                                );
                    if (policyResult.Outcome == OutcomeType.Successful)
                        return policyResult.Result;
                    else
                    {
                        throw policyResult.FinalException;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Exception retry: {attemptsCounter} ex: {ex.Message}");
                    if (attemptsCounter > 2 || ex.Data.Contains("statusCode") && short.Parse(ex.Data["statusCode"].ToString()) != 401)
                    {
                        throw;
                    }
                    tryForceRefreshToken = true;
                }
            }
        }

        public async Task<AuthResponse> AuthWithCredentialsAsync(string username, string password)
        {
            var fcmToken = Preferences.Get("TokenFirebase", string.Empty);
            var userLoginRequest = new UserLoginRequest
            {
                Username = username,
                Password = password,
                FcmToken = fcmToken
            };

            var json = JsonConvert.SerializeObject(userLoginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{Constants.BaseUrl}{AUTH_URL}", content);

            var stringResponse = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result<AuthResponse>>(stringResponse);

            if (result.Code == StatusCodes.Status200OK)
            {
                Preferences.Set("BearerToken", result.Data.BearerToken);
                Preferences.Set("RefreshToken", result.Data.RefreshToken);
                SettingsService.UsuarioId = result.Data.UsuarioId;
                SettingsService.FCMToken = result.Data.FCMToken;
                result.Data.Success = true;

                return result.Data;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        private async Task<bool> TryAuthWithRefreshTokenAsync()
        {
            try
            {
                //Tenta executar o refreshtoken apenas da primeira thread que solicitou...
                //Para as demais threads, faz com que elas aguardem pela renovacao do token.
                if (Interlocked.CompareExchange(ref _refreshTokenEntered, 1, 0) == 0)
                {

                    Debug.WriteLine("Refresh Token Renewing...");
                    //tenta renovar
                    var authResponse = await AuthWithRefreshTokenAsync();

                    Interlocked.Exchange(ref _refreshTokenEntered, 0);
                    Debug.WriteLine("Refresh Token Renewed");
                    return authResponse.Success;
                }
                else
                {
                    Debug.WriteLine("Refresh Token Renewal is Waiting...");

                    while (_refreshTokenEntered == 1)
                    {
                        await Task.Delay(100);
                    }
                    //Faz as outras threads aguardarem até que o token seja renovado no bloco anterior
                    Debug.WriteLine("Refresh Token Renewal done!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Refresh Token Unauthorized!" + ex.Message);
                Interlocked.Exchange(ref _refreshTokenEntered, 0);
                return false;
            }
        }

        public async Task<AuthResponse> AuthWithRefreshTokenAsync()
        {
            var userToken = new UserTokenRequest()
            {
                BearerToken = BearerToken,
                RefreshToken = RefreshToken
            };

            var json = JsonConvert.SerializeObject(userToken);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{Constants.BaseUrl}{REFRESH_TOKEN_URL}", content);

            var stringResponse = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result<AuthResponse>>(stringResponse);

            if (responseMessage.IsSuccessStatusCode)
            {
                Preferences.Set("BearerToken", result.Data.BearerToken);
                Preferences.Set("RefreshToken", result.Data.RefreshToken);
                SettingsService.UsuarioId = result.Data.UsuarioId;
                SettingsService.FCMToken = result.Data.FCMToken;
                result.Data.Success = true;
                await UsuarioService.RequestUsuarioProfile();

                return result.Data;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<Result<TObject>> Get<TObject>(string endpoint, object parameters)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"bearer {BearerToken}");
                client.Timeout = TimeSpan.FromSeconds(15);
                try
                {
                    var responseMessage = await client.GetAsync($"{Constants.BaseUrl}{endpoint}");

                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new Exception("Unauthorized");
                    }
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                    var response = JsonConvert.DeserializeObject<Result<TObject>>(jsonResponse);

                    return response;
                }
                catch
                {
                    throw;
                }
            }
        }

        public async Task<Result<TObject>> Post<TObject>(string endpoint, object payload)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"bearer {BearerToken}");
                client.Timeout = TimeSpan.FromSeconds(15);
                try
                {
                    var json = JsonConvert.SerializeObject(payload);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync($"{Constants.BaseUrl}{endpoint}", content);

                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new Exception("Unauthorized");
                    }
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                    var response = JsonConvert.DeserializeObject<Result<TObject>>(jsonResponse);

                    return response;
                }
                catch
                {
                    throw;
                }
            }
        }

        public async Task<Result<TObject>> PostAndUploadFile<TObject>(string endpoint, object payload, string pathFileUpload)
        {
            var json = JsonConvert.SerializeObject(payload);
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(30);

                using (var content = new MultipartFormDataContent("----MyGreatBoundary"))
                {
                    var memoryStreamFileUpload = (Stream)File.OpenRead(pathFileUpload);
                    var streamFileUpload = new StreamContent(memoryStreamFileUpload);

                    content.Add(streamFileUpload, "fileUpload", Guid.NewGuid().ToString() + ".jpg");
                    content.Add(new StringContent(json.ToString()), "ItemData");
                    try
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
                        using (var responseMessage = await httpClient.PostAsync($"{Constants.BaseUrl}{endpoint}", content))
                        {
                            // Asegurar que sea un HttpStatusCode OK
                            responseMessage.EnsureSuccessStatusCode();

                            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                            var response = JsonConvert.DeserializeObject<Result<TObject>>(jsonResponse);

                            return response;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error PostAndUploadFile: {ex}");
                        throw ex;
                    }
                }
            }
        }

        public async Task<Stream> GetStreamDocumento<TObject>(string endpoint, object payload)
        {
            var memoryStreamResponse = new MemoryStream();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"bearer {BearerToken}");
                client.Timeout = TimeSpan.FromMinutes(1);
                try
                {
                    var responseMessage = await client.GetAsync($"{Constants.BaseUrl}{endpoint}");

                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new Exception("Unauthorized");
                    }
                    // Asegurar que sea un HttpStatusCode OK
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                    await responseMessage.Content.CopyToAsync(memoryStreamResponse);
                }
                catch
                {
                    throw;
                }
            }

            return memoryStreamResponse;
        }

        public async Task<Stream> GetPdfSolicitudNotificacion<TObject>(FileManagerRequest data, string filePath)
        {
            var memoryStreamResponse = new MemoryStream();

            var bufferSize = 4 * 1024; // default
            var tries = 0;
            var statusCode = 0;
            var json = JsonConvert.SerializeObject(data);
            do
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMinutes(30);

                    using (var content = new MultipartFormDataContent("----MyGreatBoundary"))
                    {
                        if (!string.IsNullOrWhiteSpace(filePath))
                        {
                            var memoryStreamPdf = (Stream)File.OpenRead(filePath);
                            var streamPdf = new StreamContent(memoryStreamPdf);
                            content.Add(streamPdf, "firmaRecibidoUpload", Guid.NewGuid().ToString() + ".jpg");
                        }
                        content.Add(new StringContent(json.ToString()), "ItemData");
                        try
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
                            using (var response = await httpClient.PostAsync($"{Constants.BaseUrl}/api/files/upload", content))
                            {
                                statusCode = (int)response.StatusCode;

                                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                {
                                    var newToken = await TryAuthWithRefreshTokenAsync();
                                    if (newToken)
                                    {
                                        tries += 1;
                                        continue;
                                    }
                                }
                                // Asegurar que sea un HttpStatusCode OK
                                response.EnsureSuccessStatusCode();
                                await response.Content.CopyToAsync(memoryStreamResponse);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"MakeApiCall result: {ex}");
                            throw ex;
                        }
                    }
                }

            }
            while (tries < 2 && statusCode == 401);

            return memoryStreamResponse;
        }

        public async Task<Result<DocumentoFirmadoResponse>> FirmarDocumentoFIREC<TObject>(FirmarDocumentoRequest payloadData, string pathArchivoFirmar, string pathFileKey, string pathFileCertificado)
        {
            var tries = 0;
            var statusCode = 0;
            var json = JsonConvert.SerializeObject(payloadData);
            do
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMinutes(30);

                    using (var content = new MultipartFormDataContent("----MyGreatBoundary"))
                    {
                        var memoryStreamPdf = (Stream)File.OpenRead(pathArchivoFirmar);
                        var streamPdf = new StreamContent(memoryStreamPdf);
                        var memoryStreamKey = (Stream)File.OpenRead(pathFileKey);
                        var streamKey = new StreamContent(memoryStreamKey);
                        var memoryStreamCer = (Stream)File.OpenRead(pathFileCertificado);
                        var streamCer = new StreamContent(memoryStreamCer);

                        content.Add(streamPdf, "fileB64", Guid.NewGuid().ToString() + ".txt");
                        content.Add(streamKey, "fileKey", Guid.NewGuid().ToString() + ".key");
                        content.Add(streamCer, "fileCer", Guid.NewGuid().ToString() + ".cer");
                        content.Add(new StringContent(json.ToString()), "ItemData");
                        try
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
                            using (var responseMessage = await httpClient.PostAsync($"{Constants.BaseUrl}/api/documentocentral/firmar_documento", content))
                            {
                                statusCode = (int)responseMessage.StatusCode;

                                if (statusCode == (int)System.Net.HttpStatusCode.Unauthorized)
                                {
                                    var newToken = await TryAuthWithRefreshTokenAsync();
                                    if (newToken)
                                    {
                                        tries += 1;
                                        continue;
                                    }
                                }
                                // Asegurar que sea un HttpStatusCode OK
                                responseMessage.EnsureSuccessStatusCode();
                                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                                var response = JsonConvert.DeserializeObject<Result<DocumentoFirmadoResponse>>(jsonResponse);

                                return response;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"MakeApiCall result: {ex}");
                            throw ex;
                        }
                    }
                }

            }
            while (tries < 2 && statusCode == 401);

            return default;
        }


    }
}
