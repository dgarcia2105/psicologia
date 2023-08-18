//README:
//Enviar E-Mail: https://www.udemy.com/course/aprende-aspnet-core-mvc-haciendo-proyectos-desde-cero/learn/lecture/29473652#overview
//RESTService   https://www.youtube.com/watch?v=Q12rpPdPcD8
                //https://jsonplaceholder.typicode.com/
                //https://www.youtube.com/watch?v=Tj3qsKSNvMk       Add restservice to .net 6
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Gestion.DTO.Objects;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using System.Threading.Tasks;

namespace MM.CAAM.Admin.Services
{
    public interface IRESTService
    {
        Task<Result<TObject>> Get<TObject>(string endpoint, string BearerToken = "");
        Task<Result<TObject>> Post<TObject>(string endpoint, object payload, string BearerToken = "");
        Task<TObject> Put<TObject>(string endpoint, object payload, string BearerToken = "");
        Task<TObject> Delete<TObject>(string endpoint, object payload, string BearerToken = "");
    }

    public class RESTService : IRESTService
    {
        private string apiKey;
        public string ApiKey { get => apiKey; private set => apiKey = value; }

        private string baseUrlAPI;
        public string BaseUrlAPI { get => baseUrlAPI; private set => baseUrlAPI = value; }


        public RESTService(string _apiKey, string _baseUrlAPI)
        {
            ApiKey = _apiKey;
            BaseUrlAPI = _baseUrlAPI;
        }
        public RESTService()
        {
            ApiKey = "ApiKeyCaam";
            BaseUrlAPI = "https://localhost:7056";
        }



        public async Task<Result<TObject>> Post<TObject>(string endpoint, object payload, string BearerToken = "")
        {
            RestClient client = new RestClient(BaseUrlAPI + endpoint);
            RestRequest request = new RestRequest(Method.POST);
            client.Timeout = -1;

            Result<TObject> result = default;
            IRestResponse response = default;
            try
            {
                request.AddHeader("ApiKey", ApiKey);

                if (!string.IsNullOrWhiteSpace(BearerToken))
                    request.AddHeader("Authorization", $"bearer {BearerToken}");

                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(JsonConvert.SerializeObject(payload));

                response = await client.ExecuteAsync(request);

                var jsonResponse = response.Content;

                result = JsonConvert.DeserializeObject<Result<TObject>>(jsonResponse);
            }
            finally
            {
                //// Checking response, if ok go ahead, if not raise exception
                //ExceptionHandling.EnsureResponseWasSuccessful(client, request, response);
            }

            return result;
        }

        public async Task<Result<TObject>> Get<TObject>(string endpoint, string BearerToken = "")
        {
            RestClient client = new RestClient(BaseUrlAPI + endpoint);
            RestRequest request = new RestRequest(Method.GET);
            client.Timeout = -1;

            Result<TObject> result = default;
            IRestResponse response = default;
            try
            {
                request.AddHeader("ApiKey", ApiKey);

                if (!string.IsNullOrWhiteSpace(BearerToken))
                    request.AddHeader("Authorization", $"bearer {BearerToken}");
                
                response = await client.ExecuteAsync(request);

                var jsonResponse = response.Content;

                result = JsonConvert.DeserializeObject<Result<TObject>>(jsonResponse);
            }
            finally
            {
                /// Checking response, if ok go ahead, if not raise exception
                ExceptionHandling.EnsureResponseWasSuccessful(client, request, response);
            }

            return result;
        }

        public async Task<TObject> Put<TObject>(string endpoint, object payload, string BearerToken = "")
        {
            RestClient client = new RestClient(BaseUrlAPI + endpoint);
            RestRequest request = new RestRequest(Method.PUT);
            client.Timeout = -1;

            TObject result = default;
            IRestResponse response = default;
            try
            {
                request.AddHeader("ApiKey", ApiKey);

                if (!string.IsNullOrWhiteSpace(BearerToken))
                    request.AddHeader("Authorization", $"bearer {BearerToken}");

                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(JsonConvert.SerializeObject(payload));

                response = await client.ExecuteAsync(request);

                var jsonResponse = response.Content;

                result = JsonConvert.DeserializeObject<TObject>(jsonResponse);
            }
            finally
            {
                /// Checking response, if ok go ahead, if not raise exception
                ExceptionHandling.EnsureResponseWasSuccessful(client, request, response);
            }

            return result;
        }
        public async Task<TObject> Delete<TObject>(string endpoint, object payload, string BearerToken = "")
        {
            RestClient client = new RestClient(BaseUrlAPI + endpoint);
            RestRequest request = new RestRequest(Method.DELETE);
            client.Timeout = -1;

            TObject result = default;
            IRestResponse response = default;
            try
            {
                response = await client.ExecuteAsync(request);

                var jsonResponse = response.Content;

                result = JsonConvert.DeserializeObject<TObject>(jsonResponse);
            }
            finally
            {
                /// Checking response, if ok go ahead, if not raise exception
                ExceptionHandling.EnsureResponseWasSuccessful(client, request, response);
            }

            return result;
        }
    }
}