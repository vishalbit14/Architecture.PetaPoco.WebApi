using Architecture.Generic.Models.ApiModel;
using Architecture.Generic.Models.ViewModel;

namespace Architecture.Core.Infrastructure.IDataProvider
{
    public interface IUserDataProvider
    {
        ServiceResponse GetUserList(SearchUserModel searchParams, int pageSize = 10, int pageIndex = 1, string sortIndex = "ModifiedDate", string sortDirection = "DESC");
    }
}
