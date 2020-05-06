using System;
using System.Collections.Generic;
using System.Linq;

namespace Commerce.Core
{
    public class RepositoryInMemory : IRepository
    {
        readonly IDictionary<Type, IDictionary<long, object>> _data = 
            new Dictionary<Type,IDictionary<long,object>>();
        private IDictionary<long, object> GetItems<T>()
        {
            if (!_data.ContainsKey(typeof(T)))
                _data[typeof(T)] = new Dictionary<long, object>();

            return _data[typeof(T)];
        }

        public void Delete<T>(T entity) where T : class, IEntity
        {
            var items = GetItems<T>();
            items

            .Where(x => x.Key == entity.Id)
            .ToList()
            .ForEach(x => items.Remove(x.Key));

        }

        public T Get<T>(long id)
            where T :class, IEntity
        {
            var data = GetItems<T>();
            if(data.ContainsKey(id))
                return (T)data[id];
            return null;
        }

        public IQueryable<T> Query<T>() where T : class, IEntity
        {
            var items = GetItems<T>()
            .Select(x => (T)x.Value);
            return items.AsQueryable();
        }

        public long Save<T>(T entity) where T : class, IEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));          
            var itemlist = GetItems<T>();
            if(itemlist.Any(x => x.Key == entity.Id)){
                itemlist[entity.Id] = entity;
            }else
            {
                var maxId = itemlist.Count == 0 ? 0 : itemlist.Max(x => x.Key);
                entity.Id = maxId + 1;
                itemlist[entity.Id] = entity;
            }
            return entity.Id;
        }
    }
}
