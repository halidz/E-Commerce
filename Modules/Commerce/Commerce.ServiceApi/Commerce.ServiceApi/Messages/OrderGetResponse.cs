using Commerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.ServiceApi.Messages
{
    public class OrderGetResponse
    {
        public OrderView Order { get; set; }
    }
}
