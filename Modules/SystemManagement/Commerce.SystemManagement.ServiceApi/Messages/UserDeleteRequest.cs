using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Core;

namespace Commerce.SystemManagement.ServiceApi.Messages
{
    public class UserDeleteRequest : ISecureRequest

    {
        public Guid TokenId { get; set; }
        public long Id { get; set; }
    }
}
