using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Core.ViewModel;
using Commerce.SystemManagement.ViewModel;

namespace Commerce.SystemManagement.ServiceApi.Messages
{
    public class RoleSearchResponse
    {
        public PaginatedList<RoleItemView> List { get; set; }
    }
}
