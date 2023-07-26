//using MM.CAAM.Gestion.DTO.Objects;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.Net;

namespace MM.CAAM.Admin.Services.Exceptions
{
    internal static class ExceptionHandling
    {
        public static bool IsScuccessStatusCode(this HttpStatusCode responseCode)
        {
            var numericResponse = (int)responseCode;

            const int statusCodeOk = (int)HttpStatusCode.OK;

            const int statusCodeBadRequest = (int)HttpStatusCode.BadRequest;

            return numericResponse >= statusCodeOk &&
                   numericResponse < statusCodeBadRequest;
        }

        public static bool IsSuccessful(this IRestResponse response)
        {
            return response.StatusCode.IsScuccessStatusCode() &&
                   response.ResponseStatus == ResponseStatus.Completed;
        }

        public static void EnsureResponseWasSuccessful(this IRestClient client, IRestRequest request, IRestResponse response)
        {
            if (response.IsSuccessful())
            {
                return;
            }

            var requestUri = client.BuildUri(request);

            throw RestException.CreateException(requestUri, response);
        }
    }

    public class RestException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; }
        public Uri RequestUri { get; private set; }
        public string Content { get; private set; }

        public RestException(HttpStatusCode httpStatusCode, Uri requestUri, string content, string message, Exception innerException) : base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
            RequestUri = requestUri;
            Content = content;
        }

        public static RestException CreateException(Uri requestUri, IRestResponse response)
        {
            Exception innerException = null;

            var messageBuilder = string.Empty;

            Debug.WriteLine($"EndPoint [{requestUri}] response;\n");
            Debug.WriteLine($"Code: {response.StatusDescription}");
            Debug.WriteLine($"Content: {response.Content}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                messageBuilder = $"Unauthorized";
            }
            else if (!response.StatusCode.IsScuccessStatusCode())
            {
                var resultContent = response.Content;
                var result = JsonConvert.DeserializeObject<Result>(resultContent);
                messageBuilder = $"{result.Message}";
            }

            if (response.ErrorException != null)
            {
                messageBuilder = $"{response.ErrorMessage}";
                innerException = response.ErrorException;
            }

            return new RestException(response.StatusCode, requestUri, response.Content, messageBuilder.ToString(), innerException);
        }
    }
}