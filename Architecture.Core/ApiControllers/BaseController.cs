using Architecture.Generic.Infrastructure;
using Architecture.Generic.Models.ApiModel;
using Architecture.Core.Infrastructure.Attributes;
using System.Web.Http;

namespace Architecture.Core.ApiControllers
{
    public class BaseController : ApiController
    {
        [HttpGet]
        [ApiAuthorizationFilter(Permissions = Constants.AnonymousPermission)]
        public ServiceResponse Ping()
        {
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Hey! It's working. You're running Architecture.PetaPoco.WebApi project."
            };
        }
    }
}