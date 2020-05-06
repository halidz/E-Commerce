

using Commerce.Core;

namespace Commerce.SystemManagement.EntityModel
{
    public class Role : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
    }
}
