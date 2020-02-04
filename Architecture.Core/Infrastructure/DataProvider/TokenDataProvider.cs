using Architecture.Generic.Infrastructure;
using Architecture.Generic.Models;
using Architecture.Core.Infrastructure.IDataProvider;
using Architecture.Data.Infrastructure.DataProvider;
using System.Collections.Generic;
using Architecture.Generic.Models.ApiModel;
using Architecture.Generic.Models.ViewModel;
using Architecture.Generic.Resources;
using Architecture.Data.Models.Entity;

namespace Architecture.Core.Infrastructure.DataProvider
{
    public class TokenDataProvider : BaseDataProvider, ITokenDataProvider
    {
        public TokenDataProvider() : base(ConfigSettings.ConnectionStringName)
        { }

        public ServiceResponse SaveRequestResponselog(RequestResponseLog model, long loggedInUserId)
        {
            ServiceResponse response = new ServiceResponse();
            response.IsSuccess = true;
            response.Data = SaveEntity(model, loggedInUserId);
            return response;
        }

        public ServiceResponse AuthenticateToken(string token)
        {
            ServiceResponse response = new ServiceResponse();

            LoginTokenModel tokenModel = GetEntity<LoginTokenModel>(StoredProcedures.AuthenticateToken,
                new List<SearchValueData> { new SearchValueData("Token", token) });

            if (tokenModel != null)
            {
                response = Common.GenerateResponse(Resource.Success, true);
                response.Data = tokenModel;
            }
            else
            {
                response = Common.GenerateResponse(Resource.InvalidToken, true);
            }
            return response;
        }

        public ServiceResponse RemoveToken(string token)
        {
            ServiceResponse response = new ServiceResponse();

            var tokenModel = GetScalar(StoredProcedures.RemoveToken,
                new List<SearchValueData> { new SearchValueData("Token", token) });

            response = Common.GenerateResponse(Resource.LoginSuccessMessage, true);
            return response;
        }
    }
}
