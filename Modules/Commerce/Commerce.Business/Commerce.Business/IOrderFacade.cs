using Commerce.Core.ViewModel;
using Commerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.Business
{
    public interface IOrderFacade
    {
        long Create(OrderView order);

        OrderView Get(long id);

        OrderViewDetailed GetDetailed(long id);
        PaginatedList<OrderView> Search(OrderSearchFilter filter, PaginationInfoView paginationInfo);

        void Delete(long id);

        void Update(OrderView order);
    }
}
