using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.ViewModel
{
    public class ShippingView
    {
        public long Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Company { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
