using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Business;
using Commerce.ServiceApi.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.ServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderFacade _facade;
        public OrderController(IOrderFacade facade)
        {
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
        }


        [HttpPost("Create")]
        public OrderCreateResponse Create (OrderCreateRequest request)
        {
            var response = new OrderCreateResponse();
            _facade.Create(request.Order);
            return response;
        }

        [HttpPost("Search")]
        public OrderSearchResponse Search(OrderSearchRequest request)
        {
            var response = new OrderSearchResponse();
            response.List= _facade.Search(request.Filter,request.PaginationInfo);
            return response;
        }

        [HttpPost("Update")]
        public OrderUpdateResponse Update(OrderUpdateRequest request)
        {
            var response = new OrderUpdateResponse();
            _facade.Update(request.Order);
            return response;
        }

        [HttpPost("Delete")]
        public OrderDeleteResponse Delete(OrderDeleteRequest request)
        {
            var response = new OrderDeleteResponse();
            _facade.Delete(request.ID);
            return response;
        }

        [HttpPost("Get")]
        public OrderGetResponse Get(OrderGetRequest request)
        {
            var response = new OrderGetResponse();
            _facade.Get(request.Id);
            return response;
        }

    }
}