using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Core;
using Commerce.SystemManagement.ViewModel;

namespace Commerce.SystemManagement.ServiceApi.Messages
{
    public class RoleUpdateRequest : ISecureRequest
    {
        public Guid TokenId { get; set; }
        public RoleItemView Role { get; set; }
    }
}
