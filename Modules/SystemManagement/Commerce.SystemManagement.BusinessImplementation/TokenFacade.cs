using Commerce.Core;
using Commerce.SystemManagement.Business;
using Commerce.SystemManagement.EntityModel;
using Commerce.SystemManagement.ViewModel;
using System;
using System.Linq;


namespace Commerce.SystemManagement.BusinessImplementation
{
    public class TokenFacade : ITokenFacade
    {
        private readonly IRepository _repository;

        public TokenFacade(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public long Create(LoginView login)
        {
            var userQuery = _repository.Query<User>();
            var tokenQuery = _repository.Query<Token>();
            userQuery = userQuery.Where(x => x.UserName == login.UserName);
            if (userQuery.Count() == 0)
            {
                return -1;
               // throw new Exception("USERNAME IS NOT VALID");
            }
            else
            {
                var user = userQuery.Where(x => x.UserName == login.UserName).ToList().First();
               // tokenQuery = tokenQuery.Where(x => x.UserID == user.Id);
               // var token = tokenQuery.Where(x => x.ExpireDate < DateTime.Now).ToList().First();
                if (user != null && user.Password == login.Password)
                {
                        return _repository.Save(new Token
                        {
                            TokenId = Guid.NewGuid(),
                            UserID = user.Id,
                            UserName = user.UserName,
                            CreateDate = DateTime.Now.ToLocalTime(),
                            ExpireDate = DateTime.Now.ToLocalTime().AddMinutes(30)
                        });
                }
                else
                {
                    return -1;
                    // throw new Exception("USERNAME AND PASSWORD NOT VALID");
                }
            }
        }

        public TokenView GetWithTokenId(Guid id)
        {
            var query = _repository.Query<Token>();
            var entityId = query.Where(x => x.TokenId == id).ToList().First().Id;

            var entity= _repository.Get<Token>(entityId);
            if (entity == null)
                return null;
            return new TokenView
            {
                TokenId = entity.TokenId,
                CreateDate = entity.CreateDate,
                ExpireDate = entity.ExpireDate,
                Id = entity.Id,
                UserID = entity.UserID,
                UserName = entity.UserName
            };
        }

        public TokenView Get(long id)
        {
            var entity = _repository.Get<Token>(id);
            if (entity == null)
                return null;
            return new TokenView
            {
                TokenId = entity.TokenId,
                CreateDate = entity.CreateDate,
                ExpireDate = entity.ExpireDate,
                Id = entity.Id,
                UserID = entity.UserID,
                UserName = entity.UserName
            };
        }

        public string GetAuth(long id)
        {
            var entity = _repository.Get<Token>(id);
            if (entity == null)
                return null;
            var query = _repository.Query<User>();
            var user = query.Where(x => x.Id == entity.UserID).ToList().First();
            if (user == null)
                return null;
            if (user.Roles.Count == 0)
                return "user";
            return user.Roles.First().Code;
        }
    }
}
