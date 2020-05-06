using Commerce.Core;
using Commerce.Core.ViewModel;
using Commerce.SystemManagement.Business;
using Commerce.SystemManagement.EntityModel;
using Commerce.SystemManagement.ViewModel;
using System;
using System.Linq;


namespace Commerce.SystemManagement.BusinessImplementation
{
    public class RoleFacade : IRoleFacade
    {
        private readonly IRepository _repository;
        public RoleFacade(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public long Create(RoleItemView role)
        {
           var query = _repository.Query<Role>();
            if (!string.IsNullOrWhiteSpace(role.Name))
            {
                query = query.Where(x => x.Name == role.Name);
            }           
            if (query.Count() > 0)
            {
                return -1;
            }
            else
            {
                return _repository.Save(new Role
                {
                    Name = role.Name,
                    Code = role.Code
                });
            }
        }

      
        public void Delete(long id)
        {
            var entity = _repository.Get<Role>(id);
            _repository.Delete(entity);
        }

        public RoleItemView Get(long id)
        {
            var role= _repository.Get<Role>(id);
            if (role == null)
            {
                return null;
            }
            var view = new RoleItemView
            {
                Name = role.Name,
                Code = role.Code,
                Id = role.Id
            };
            return view;
        }

        public PaginatedList<RoleItemView> Search(RoleSearchFilter filter, PaginationInfoView paginationInfo)
        {
            var query = _repository.Query<Role>();
            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(x => x.Name == filter.Name);
            }
            if (!string.IsNullOrWhiteSpace(filter.Code))
            {
                query = query.Where(x => x.Code == filter.Code);
            }
            var newQuery = query.Select(
                x => new RoleItemView
               {
                    Name=x.Name,
                    Code=x.Code,
                    Id=x.Id
               });
            return new PaginatedList<RoleItemView>(paginationInfo, newQuery);
        }

     

        public void Update(RoleItemView role)
        {
            _repository.Save(new Role
            {
                Name = role.Name,
                Code = role.Code,
                Id = role.Id
            });
        }

  
    }
}
