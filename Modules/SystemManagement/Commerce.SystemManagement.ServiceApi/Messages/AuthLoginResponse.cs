using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.SystemManagement.ServiceApi.Messages
{
    public class AuthLoginResponse
    {
        public Guid TokenId { get; set; }
        public string Code { get; set; }
                       
        public DateTime? ExpireDate { get; set; }



    }
}
