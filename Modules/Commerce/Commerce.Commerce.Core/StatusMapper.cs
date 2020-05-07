using Commerce.Core;
using System;

namespace Commerce.Commerce.Core
{
    public class StatusMapper
    {
        public OrderStatus Map(String status)
        {
            status = status.Trim().ToLower();
            switch (status)
            {
                case "pending":
                    return OrderStatus.Pending;            
                case "processing":
                    return OrderStatus.InCargo;                  
                case "on - hold":
                    return OrderStatus.Passive;                   
                case "completed":
                    return OrderStatus.Delivered;                  
                case "cancelled":
                    return OrderStatus.Cancelled; ;
                case "refunded":
                    return OrderStatus.Refunded; ;
                case "trash":
                    return OrderStatus.Trash;
                default:
                    return OrderStatus.None;

            }
           


        }
    }
}
