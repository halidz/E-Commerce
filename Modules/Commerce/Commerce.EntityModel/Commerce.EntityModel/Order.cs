using Commerce.Core;
using System;

namespace Commerce.EntityModel
{
    public class Order : IEntity
    {
        public virtual long Id {get ; set;}
        public virtual bool IsLast { get; set; }
        public virtual long RefId { get; set; }
        public virtual long CompanyId { get; set; }
        public virtual long CustomerId { get; set; }
        public virtual string CustomerIpAddress { get; set; }
        public virtual string CustomerNote { get; set; }
        public virtual long ProductId { get; set; }
        public virtual string PaymentMethod { get; set; }
        public virtual bool SetPaid { get; set; }
        public virtual string Currency { get; set; }
        public virtual decimal Total { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual decimal ShippingTotal { get; set; }
        public virtual Status Status { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual long Date { get; set; }
        public virtual long Date_paid { get; set; }
        
        public virtual string Description { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string CreatedByFullName { get; set; }
        public virtual long CreatedDate { get; set; }  //YIL_AY_GUN_SAAT_DAKIKA_SANIYE 2 karakter for all
        public virtual string UpdatedBy { get; set; }
        public virtual string UpdatedByFullName { get; set; }
        public virtual long UpdatedDate { get; set; }
       

    }
}
