

using Commerce.Core.ViewModel;
using Commerce.SystemManagement.ViewModel;

namespace Commerce.SystemManagement.Business
{
    public interface IRoleFacade
    {
        long Create(RoleItemView role);

        void Update(RoleItemView role);

        PaginatedList<RoleItemView> Search(RoleSearchFilter filter,PaginationInfoView paginationInfo);

        RoleItemView Get(long id);

        void Delete(long id);
    }
}
