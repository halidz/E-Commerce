using Commerce.Core;
using System;


namespace Commerce.SystemManagement.EntityModel
{
    public class Token : IEntity
    {
        public virtual long Id { get; set; }
        public virtual Guid TokenId { get; set; }
        public virtual string UserName { get; set; }
        public virtual long UserID { get; set; }
        public virtual DateTime? ExpireDate { get; set; }
        public virtual DateTime CreateDate { get; set; }
    }
}
