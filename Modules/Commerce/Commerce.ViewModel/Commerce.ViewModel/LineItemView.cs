using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.ViewModel
{
    public class LineItemView
    {
        public long Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Product_id { get; set; }
        public int Variation_id { get; set; }
        public int Quantity { get; set; }
        public string Tax_class { get; set; }
        public string Subtotal { get; set; }      //Line subtotal(before discounts).
        public string Subtotal_tax { get; set; }//Line subtotal tax(before discounts).READ-ONLY
        public string Total { get; set; }                   //Line total(after discounts).
        public string Total_tax { get; set; }          //Line total tax(after discounts).READ-ONLY
        //public array taxes    Line taxes.See Order - Taxes propertiesREAD-ONLY
        //public array meta_data    Meta data.See Order - Meta data properties
        public string Sku { get; set; }
        public string Price { get; set; }
    }
}
