using MM.CAAM.Gestion.DTO.Objects;
using MM.CAAM.Gestion.DTO.Test;
using System.Net;
using System.Threading.Tasks;

namespace MM.CAAM.Admin.Services.Servicios.Test
{
    public interface ITestService
    {
        Task<Result<Post>> PostTest(Post post);
        Task<Post> PutTest(Post post);
        Task<Post> DeleteTest(Post post);
    }
    public class TestService : ITestService
    {
        private readonly IRESTService RESTService;
        public TestService(IRESTService restService) 
        {
            RESTService = restService;
        }
        public async Task<Result<Post>> PostTest(Post payload)
        {
            var endPoint = $"/posts";

            var result = await RESTService.Post<Post>(endPoint, payload, "");

            //if (result.Code != (int)HttpStatusCode.OK)
            //    throw new ValidationException(result.Message);

            //return result.Data;

            return result;
        }

        public async Task<Post> PutTest(Post payload)
        {
            var endPoint = $"/posts/99";

            var result = await RESTService.Put<Post>(endPoint, payload, "");

            //if (result.Code != (int)HttpStatusCode.OK)
            //    throw new ValidationException(result.Message);

            //return result.Data;

            return result;
        }

        public async Task<Post> DeleteTest(Post payload)
        {
            var endPoint = $"/posts/99";

            var result = await RESTService.Delete<Post>(endPoint, payload, "");

            //if (result.Code != (int)HttpStatusCode.OK)
            //    throw new ValidationException(result.Message);

            //return result.Data;

            return result;
        }
    }
}
