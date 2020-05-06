using Commerce.Core.ViewModel;
using Commerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.Business
{
    public interface IProductFacade
    {
        long CreateForWP(ProductView product);
        long Create(ProductView product);

        ProductView Get(long id);

        PaginatedList<ProductView> Search(ProductSearchFilter filter, PaginationInfoView paginationInfo);

        void Delete(long id);

        void Update(ProductView product);
    }
}
