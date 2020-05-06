

using Commerce.Core.ViewModel;
using Commerce.SystemManagement.ViewModel;

namespace Commerce.SystemManagement.Business
{
    public interface IUserFacade
    {
        long Create(UserEditView user);
        void Update(UserEditView user);
        PaginatedList<UserItemView> Search(UserSearchFilter filter,PaginationInfoView paginationInfo);
        UserDetailView Get(long id);
        void Delete(long id);
    }
}
