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
    public class InvokeController : ControllerBase
    {
        IWordPressConnector _connector;

        public InvokeController(IWordPressConnector connector)
        {
            _connector = connector ?? throw new ArgumentNullException(nameof(connector));
        }


        [HttpPost("Invoke")]

        public InvokeResponse Invoke(InvokeRequest request)
        {

            var response = new InvokeResponse();
            response.Count=_connector.QueryOrder();
            return response;

        }

        [HttpPost("ListProduct")]

        public ListProductResponse ListProduct(ListProductRequest request)
        {

            var response = new ListProductResponse();
            response.List = _connector.ListProduct();
            return response;

        }


        [HttpPost("InvokeProduct")]

        public InvokeProductResponse InvokeProduct(InvokeProductRequest request)
        {

            var response = new InvokeProductResponse();
            _connector.QueryProduct();
            return response;

        }
    }
}