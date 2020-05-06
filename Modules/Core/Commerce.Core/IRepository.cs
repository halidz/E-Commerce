using System.Linq;
namespace Commerce.Core
{
    public interface IRepository
    {
        T Get<T>(long id) where T : class, IEntity;
        long Save<T>(T entity) where T : class, IEntity;
        void Delete<T>(T entity) where T : class, IEntity;
        IQueryable<T> Query<T>() where T : class, IEntity;
    }
}
