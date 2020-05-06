using Commerce.SystemManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Commerce.SystemManagement.ServiceApi.Messages
{
    public class AuthLoginRequest
    {
        public LoginView Login { get; set; }
    }
}
