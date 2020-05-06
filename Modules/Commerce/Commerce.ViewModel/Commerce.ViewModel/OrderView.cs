using Commerce.Core;
using System;

namespace Commerce.ViewModel
{
    public class OrderView
    {
        public  long Id { get; set; }

        public long RefId { get; set; }

        public bool IsLast { get; set; }
        public  long CompanyId { get; set; }

        public  long ProductId { get; set; }

        public  Status Status { get; set; }

        public  string Description { get; set; }
    }
}
