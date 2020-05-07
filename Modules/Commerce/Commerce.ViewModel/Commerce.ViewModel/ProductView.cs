using Commerce.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.ViewModel
{
    public class ProductView
    {
        public long Id { get; set; }

        public long CategoryId { get; set; }
        public int? RefId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public string Type { get; set; }
        public bool IsLast { get; set; }
        public Status Status { get; set; }

        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }

}
