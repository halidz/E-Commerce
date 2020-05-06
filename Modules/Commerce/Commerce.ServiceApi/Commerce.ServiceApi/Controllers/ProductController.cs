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
    public class ProductController : ControllerBase
    {
        public IProductFacade _facade;
        public ProductController(IProductFacade facade)
        {
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
        }

        [HttpPost("Create")]
        public ProductCreateResponse Create(ProductCreateRequest request)
        {
            var response = new ProductCreateResponse();
            _facade.Create(request.Product);
            return response;
        }

        [HttpPost("Search")]
        public ProductSearchResponse Search(ProductSearchRequest request)
        {
            var response = new ProductSearchResponse();
            response.List = _facade.Search(request.Filter, request.PaginationInfo);
            return response;
        }

        [HttpPost("Update")]
        public ProductUpdateResponse Update(ProductUpdateRequest request)
        {
            var response = new ProductUpdateResponse();
            _facade.Update(request.Product);
            return response;
        }

        [HttpPost("Delete")]
        public ProductDeleteResponse Delete(ProductDeleteRequest request)
        {
            var response = new ProductDeleteResponse();
            _facade.Delete(request.ID);
            return response;
        }

        [HttpPost("Get")]
        public ProductGetResponse Get(ProductGetRequest request)
        {
            var response = new ProductGetResponse();
            _facade.Get(request.Id);
            return response;
        }
    }
}