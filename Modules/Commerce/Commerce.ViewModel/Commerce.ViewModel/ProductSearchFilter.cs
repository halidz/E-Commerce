using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.ViewModel
{
    public class ProductSearchFilter
    {
        public long Id { get; set; }
        public int? RefId { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
               

    }
}
