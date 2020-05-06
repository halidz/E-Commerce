using Commerce.Core.ViewModel;
using Commerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.ServiceApi.Messages
{
    public class ProductSearchRequest
    {
        public ProductSearchFilter Filter { get; set; }

        public PaginationInfoView PaginationInfo { get; set; }
    }
}
