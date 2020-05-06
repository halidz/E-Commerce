using Commerce.Core;
using Commerce.Core.ViewModel;
using Commerce.SystemManagement.Business;
using Commerce.SystemManagement.EntityModel;
using Commerce.SystemManagement.ViewModel;
using System;
using System.Linq;


namespace Commerce.SystemManagement.BusinessImplementation
{
    public class UserFacade : IUserFacade
    {
        private readonly IRepository _repository;
        public UserFacade(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public long Create(UserEditView user)
        {
            var query = _repository.Query<User>()
                .Where(x => x.UserName == user.UserName);
            if (query.Count() != 0)
                return -1;
           return  _repository.Save(new User {
               FirstName = user.FirstName ,
               LastName = user.LastName,
               Email = user.Email,
               Password =user.Password,
               Status =user.Status,
               UserName =user.UserName
           });
        }

        public void Delete(long id)
        {
            var entity = _repository.Get<User>(id);
            entity.Status = Core.UserStatus.Passive;
            _repository.Save(entity);
        }

        public UserDetailView Get(long id)
        {
            var entity = _repository.Get<User>(id);
            if (entity == null)
                return null;
            var view = new UserDetailView
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Status = entity.Status,
                UserName = entity.UserName,
                Roles = entity.Roles.Select(x =>
                  new RoleItemView
                  {
                      Code = x.Code,
                      Id = x.Id,
                      Name = x.Name
                  }).ToList()
            };
            return view;
        }
        public void Update(UserEditView user)
        {
            var entity = _repository.Get<User>(user.Id);
            if (entity == null)
                throw new Exception("User not found");
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;
            entity.Password = user.Password;
            entity.Status = user.Status;
            entity.UserName = user.UserName;
            entity.Roles = user.Roles.Select(x =>
            new Role
            {

                Id = x.Id,


            }).ToList();
            _repository.Save(entity);
        }

        public PaginatedList<UserItemView> Search(UserSearchFilter filter, PaginationInfoView paginationInfo)
        {
            var query = _repository.Query<User>()
                .Where(x => x.Status == Core.UserStatus.Active);
            if (!string.IsNullOrWhiteSpace(filter.UserName))
                query = query.Where(x => x.UserName == filter.UserName);
            if (!string.IsNullOrWhiteSpace(filter.FirstName))
                query = query.Where(x => x.FirstName == filter.FirstName);
            if (!string.IsNullOrWhiteSpace(filter.LastName))
                query = query.Where(x => x.LastName == filter.LastName);
            if (filter.Status != Core.UserStatus.None)
                query = query.Where(x => x.Status == filter.Status);
            var newQuery = query.Select(
              x => new UserItemView
              {
                  FirstName = x.FirstName,
                  LastName = x.LastName,
                  UserName=x.UserName,
                  Status=x.Status,
                  Id=x.Id
              });
            return new PaginatedList<UserItemView>(paginationInfo,newQuery);
        }
    }
}
