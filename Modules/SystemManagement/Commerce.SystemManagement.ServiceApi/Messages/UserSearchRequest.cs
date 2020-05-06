using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Core;
using Commerce.Core.ViewModel;
using Commerce.SystemManagement.ViewModel;

namespace Commerce.SystemManagement.ServiceApi.Messages
{
    public class UserSearchRequest : ISecureRequest
    {
        public Guid TokenId { get; set; }
        public UserSearchFilter Filter { get; set; }
        public PaginationInfoView PaginationInfo { get; set; }
    }
}
