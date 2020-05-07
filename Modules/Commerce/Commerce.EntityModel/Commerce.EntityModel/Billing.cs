using Commerce.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.EntityModel
{
    public class Billing : IEntity
    {
        public virtual long Id {get; set;}
        public virtual string First_name { get; set; }
        public virtual string Last_name { get; set; }
        public virtual string Company { get; set; }
        public virtual string Address_1 { get; set; }
        public virtual string Address_2 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Postcode { get; set; }
        public virtual string Country { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
    }
}
