using System;

namespace Commerce.Core
{
    public interface ISecureRequest
    {
         Guid TokenId { get; set; }
    }
}
