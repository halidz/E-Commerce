using Commerce.Core;
using Commerce.SystemManagement.Core;
using System.Collections.Generic;

namespace Commerce.SystemManagement.EntityModel
{
    public class User :IEntity
    {
        public virtual long Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual UserStatus Status { get; set; }
        public virtual IList<Role> Roles{ get; set; }
    }
}
