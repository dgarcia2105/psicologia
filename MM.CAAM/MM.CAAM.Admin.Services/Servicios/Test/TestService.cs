using MM.CAAM.Admin.DTOs.Test;
using MM.CAAM.Admin.Services.Exceptions;
using System.Net;
using System.Threading.Tasks;

namespace MM.CAAM.Admin.Services.Servicios.Test
{
    public interface ITestService
    {
        Task<Post> PostTest(Post post);
    }
    public class TestService : ITestService
    {
        private readonly IRESTService RESTService;
        public TestService(IRESTService restService) 
        {
            RESTService = restService;
        }
        public async Task<Post> PostTest(Post payload)
        {
            var endPoint = $"/posts";

            var result = await RESTService.Post<Post>(endPoint, payload, "");

            if (result.Code != (int)HttpStatusCode.OK)
                throw new ValidationException(result.Message);

            return result.Data;
        }
    }
}
