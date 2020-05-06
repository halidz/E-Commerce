using NHibernate;
using System;
using System.Linq;


namespace Commerce.Core
{
    public class NhRepository : IRepository
    {
        private readonly INhHelper _nhHelper;
        protected ISession Session
        {
            get
            {
                return _nhHelper.Session;
            }
        }

        public NhRepository(INhHelper nhHelper)
        {
            _nhHelper = nhHelper ?? throw new ArgumentNullException(nameof(nhHelper));
        }
        public void Delete<T>(T entity)
            where T : class, IEntity
        {
            Session.Delete(entity);
            Session.Flush();
        }

        public T Get<T>(long id)
            where T : class, IEntity
        {
            return Session.Get<T>(id);
        }

        public IQueryable<T> Query<T>()
            where T : class, IEntity
        {
            return Session.Query<T>();
        }

        public long Save<T>(T entity)
            where T : class, IEntity
        {
            Session.SaveOrUpdate(entity);
            Session.Flush();
            return entity.Id;
        }
    }
}
