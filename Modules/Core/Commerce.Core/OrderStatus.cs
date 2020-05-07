using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.Core
{
    public enum OrderStatus
    {
        None = 0,
        InCargo = 1,
        Delivered =2,
        Passive = 3,
        Pending = 4,
        Cancelled = 5,
        Refunded = 6,
        Trash = 7
    }
}
