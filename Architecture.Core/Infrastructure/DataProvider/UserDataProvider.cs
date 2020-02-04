using Architecture.Generic.Infrastructure;
using Architecture.Generic.Models;
using Architecture.Generic.Models.ViewModel;
using Architecture.Generic.Resources;
using Architecture.Core.Infrastructure.IDataProvider;
using Architecture.Data.Infrastructure.DataProvider;
using System.Collections.Generic;
using Architecture.Generic.Models.ApiModel;

namespace Architecture.Core.Infrastructure.DataProvider
{
    public class UserDataProvider : BaseDataProvider, IUserDataProvider
    {
        public UserDataProvider() : base(ConfigSettings.ConnectionStringName)
        {
        }

        public ServiceResponse GetUserList(SearchUserModel searchParams, int pageSize = 10, int pageIndex = 1, string sortIndex = "ModifiedDate", string sortDirection = "DESC")
        {
            ServiceResponse response = new ServiceResponse();

            List<SearchValueData> searchData = new List<SearchValueData> {
                new SearchValueData { Name = "searchText", Value = searchParams.SearchText }
            };
            var userList = GetEntityPageList<UserListModel>(StoredProcedures.GetUserList, searchData, pageSize, pageIndex, sortIndex, sortDirection);

            response = Common.GenerateResponse(Resource.Success, true);
            response.Data = new List<UserListModel>();
            return response;
        }
    }
}
