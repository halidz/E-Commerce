using Commerce.SystemManagement.ViewModel;
using System;


namespace Commerce.SystemManagement.Business
{
    public interface ITokenFacade
    {
        long Create(LoginView Token);
        TokenView GetWithTokenId(Guid id);
        TokenView Get(long id);
        string GetAuth(long id);
    }
}
