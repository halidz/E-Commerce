using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.SystemManagement.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Commerce.SystemManagement.ServiceApi.Messages;

namespace Commerce.SystemManagement.ServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade _facade;

        public UserController(IUserFacade facade)
        {
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
        }

        [HttpPost("create")]
        public UserCreateResponse Create([FromBody]UserCreateRequest request)
        {
            
            var response = new UserCreateResponse();

            response.Id = _facade.Create(request.User);

            return response;

        }

        [HttpPost("update")]
        public UserUpdateResponse Update([FromBody]UserUpdateRequest request)
        {
           
            var response = new UserUpdateResponse();
            _facade.Update(request.User);

            return response;

        }

        [HttpPost("search")]
        public UserSearchResponse Search(UserSearchRequest request)
        {
          
            var response = new UserSearchResponse();

            response.List = _facade.Search(request.Filter, request.PaginationInfo);

            return response;
        }


        [HttpPost("detail")]
        public UserGetResponse Get([FromBody]UserGetRequest request)
        {
          

            var response = new UserGetResponse();

            response.User = _facade.Get(request.Id);

            return response;
        }

        [HttpPost("delete")]

        public UserDeleteResponse Delete([FromBody]UserDeleteRequest request)
        {
          

            var response = new UserDeleteResponse();
            _facade.Delete(request.Id);
            return response;

        }



    }
}