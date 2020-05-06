

using NHibernate;

namespace Commerce.Core
{
    public interface INhHelper
    {
        ISession Session { get; }
    }
}
