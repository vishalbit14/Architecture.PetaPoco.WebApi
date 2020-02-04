using Architecture.Generic.Models.ApiModel;
using Architecture.Data.Models.Entity;

namespace Architecture.Core.Infrastructure.IDataProvider
{
    public interface ITokenDataProvider
    {
        ServiceResponse SaveRequestResponselog(RequestResponseLog model, long loggedInUserId);
        ServiceResponse AuthenticateToken(string token);
        ServiceResponse RemoveToken(string token);
    }
}
