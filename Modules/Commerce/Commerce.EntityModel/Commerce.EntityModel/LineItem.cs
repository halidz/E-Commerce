using Commerce.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.EntityModel
{
    public class LineItem:IEntity
    {
        public virtual long Id { get; set; }
        public virtual int ItemId { get; set; }
        public virtual string Name { get; set; }
        public virtual int Product_id { get; set; }
        public virtual int Variation_id { get; set; }
        public virtual int Quantity { get; set; }
        public virtual string Tax_class { get; set; }
        public virtual string Subtotal { get; set; }      //Line subtotal(before discounts).
        public virtual string Subtotal_tax { get; set; }//Line subtotal tax(before discounts).READ-ONLY
        public virtual string Total { get; set; }                   //Line total(after discounts).
        public virtual string Total_tax { get; set; }          //Line total tax(after discounts).READ-ONLY
        //public array taxes    Line taxes.See Order - Taxes propertiesREAD-ONLY
        //public array meta_data    Meta data.See Order - Meta data properties
        public virtual string Sku { get; set; }
        public virtual string Price { get; set; }
    }
}
