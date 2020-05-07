using Commerce.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.ViewModel
{
    public class OrderViewDetailed
    {
        public long Id { get; set; }
        public long RefId { get; set; }
        public bool IsLast { get; set; }
        public long CompanyId { get; set; }
        public long ProductId { get; set; }
        public string PaymentMethod { get; set; }
        public bool? SetPaid { get; set; }
        public string Currency { get; set; }
        public decimal? Total { get; set; }
        public decimal? Discount { get; set; }
        public Status Status { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Description { get; set; }

        public BillingView Billing { get; set; }

        public ShippingView Shipping { get; set; }
    }
}
