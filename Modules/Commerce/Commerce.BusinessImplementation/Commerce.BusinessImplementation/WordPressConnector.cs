using Commerce.Business;
using Commerce.Core;
using System;
using System.Collections.Generic;
using System.Text;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;
using Commerce.EntityModel;
using System.Linq;
using Commerce.ViewModel;
using Commerce.Core.ViewModel;

namespace Commerce.BusinessImplementation
{
    public class WordPressConnector : IWordPressConnector
    {
        private readonly IRepository _repository;

        public WordPressConnector(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public int QueryOrder()
        {
            RestAPI rest = new RestAPI("https://www.ne-ararsan.com/wp-json/wc/v2/", "ck_6c2e256b3a1fc9857e78d095dadc6dcd47d7df57", "cs_d83dea91af83a7a92fc014300d9472475ef78fe6");
            WCObject wc = new WCObject(rest);
            var counter = 0;
            var orders = wc.Order.GetAll();
            orders.Wait();
            var count = orders.Result.Count;
            var query = _repository.Query<Commerce.EntityModel.Order>();
            var list = query.ToList();
            if (list.Count == 0)
            {
                var orderInstance = orders.Result[0];
                _repository.Save<Commerce.EntityModel.Order>(new Commerce.EntityModel.Order { RefId = Convert.ToInt64(orderInstance.id), CreatedDate = DateTime.Now.ToDateTime(), IsLast = true, Status = Status.Active });
                for (int i = 1; i < count; i++)
                {
                    orderInstance = orders.Result[i];                  
                    _repository.Save<Commerce.EntityModel.Order>(new Commerce.EntityModel.Order { RefId = Convert.ToInt64(orderInstance.id), CreatedDate = DateTime.Now.ToDateTime(), IsLast = false, Status = Status.Active });
                }
                counter = count;
            }
            else
            {
                var lastDate = list.Max(x => x.CreatedDate);
                var lastOrders = list.Where(x => x.CreatedDate == lastDate);
                var lastOrder = lastOrders.Where(x => x.IsLast == true).FirstOrDefault();


                var idOfLastOrder = orders.Result[0].id;

                //int vs long
                if (idOfLastOrder == lastOrder.RefId)
                {

                }
                else
                {

                    var index = orders.Result.FindIndex(x => x.id == lastOrder.RefId);
                    if (index < 0)
                    {
                        throw new Exception("Cant find results in db");
                    }

                    var orderInstance = orders.Result[0];

                    for (int i = index - 1; i >= 1; i--)
                    {
                        counter = counter + 1;
                        orderInstance = orders.Result[i];

                        _repository.Save<Commerce.EntityModel.Order>(new Commerce.EntityModel.Order { RefId = Convert.ToInt64(orderInstance.id), CreatedDate = DateTime.Now.ToDateTime(), IsLast = false ,Status=Status.Active});
                    }
                    orderInstance = orders.Result[0];
                    counter = counter + 1;
                    _repository.Save<Commerce.EntityModel.Order>(new Commerce.EntityModel.Order { RefId = Convert.ToInt64(orderInstance.id), CreatedDate = DateTime.Now.ToDateTime(), IsLast = true, Status = Status.Active });

                    lastOrder.IsLast = false;
                    _repository.Save<Commerce.EntityModel.Order>(lastOrder);

                    //orderInstance =cu
                }
            }
            return counter;
        }

        public PaginatedList<ProductView> ListProduct()
        {
            RestAPI rest = new RestAPI("https://www.ne-ararsan.com/wp-json/wc/v2/", "ck_6c2e256b3a1fc9857e78d095dadc6dcd47d7df57", "cs_d83dea91af83a7a92fc014300d9472475ef78fe6");
            WCObject wc = new WCObject(rest);

            var products = wc.Product.GetAll();
            products.Wait();

            
            var newQuery = products.Result.Select(x => new ProductView
            {
                Name = x.name,
                Image = x.images.FirstOrDefault().src,
                Price = x.regular_price,
                Description = x.description

            }).AsQueryable();
            PaginatedList<ProductView> list = new PaginatedList<ProductView>(new PaginationInfoView {
                PageSize=30,
                PageIndex=1

            },newQuery);
            return list;
        }
        public void QueryProduct()
        {
            RestAPI rest = new RestAPI("https://www.ne-ararsan.com/wp-json/wc/v2/", "ck_6c2e256b3a1fc9857e78d095dadc6dcd47d7df57", "cs_d83dea91af83a7a92fc014300d9472475ef78fe6");
            WCObject wc = new WCObject(rest);
          
            var products = wc.Product.GetAll();
            products.Wait();
            var count = products.Result.Count;
            var query = _repository.Query<EntityModel.Product>();
            var list = query.ToList();
            if (list.Count == 0)
            {
                var productInstance = products.Result[0];
                _repository.Save<EntityModel.Product>(new EntityModel.Product
                {
                    Name= productInstance.name,
                    RefId= productInstance.id,
                    Image = productInstance.images.FirstOrDefault().src,
                    Price = productInstance.regular_price,
                    Description = productInstance.description,
                    IsLast = true,
                    CreatedDate = DateTime.Now.ToDateTime(),
                    Status = Status.Active
                });

                for (int i = 1; i < count; i++)
                {
                    productInstance = products.Result[i];
                    _repository.Save<EntityModel.Product>(new EntityModel.Product
                    {

                        Name = productInstance.name,
                        RefId = productInstance.id,
                        Image = productInstance.images.FirstOrDefault().src,
                        Price = productInstance.regular_price,
                        Description = productInstance.description,
                        IsLast = false,
                        CreatedDate = DateTime.Now.ToDateTime(),
                        Status=Status.Active

                    });
                }
            }
            else
            {
                var lastDate = list.Max(x => x.CreatedDate);
                var lastOrders = list.Where(x => x.CreatedDate == lastDate);
                var lastOrder = lastOrders.Where(x => x.IsLast == true).FirstOrDefault();


                var idOfLastOrder = products.Result[0].id;

                //int vs long
                if (idOfLastOrder == lastOrder.RefId)
                {


                }
                else
                {

                    var index = products.Result.FindIndex(x => x.id == lastOrder.RefId);
                    if (index < 0)
                    {
                        throw new Exception("Cant find results in db");
                    }

                    var productInstance = products.Result[0];

                    for (int i = index - 1; i >= 1; i--)
                    {
                        productInstance = products.Result[i];

                        _repository.Save<Commerce.EntityModel.Product>(new Commerce.EntityModel.Product
                        {

                            Name = productInstance.name,
                            RefId = productInstance.id,
                            Image = productInstance.images.FirstOrDefault().src,
                            Price = productInstance.regular_price,
                            Description = productInstance.description,
                            CreatedDate = DateTime.Now.ToDateTime(),
                            IsLast = false,
                            Status = Status.Active
                        });
                    }
                    productInstance = products.Result[0];

                    _repository.Save<Commerce.EntityModel.Product>(new Commerce.EntityModel.Product
                    {

                        Name = productInstance.name,
                        RefId = productInstance.id,
                        Image = productInstance.images.FirstOrDefault().src,
                        Price = productInstance.regular_price,
                        Description = productInstance.description,
                        CreatedDate = DateTime.Now.ToDateTime(),
                        IsLast = true,
                        Status = Status.Active
                    });

                    lastOrder.IsLast = false;
                    _repository.Save<Commerce.EntityModel.Product>(lastOrder);

                }
            }

        }
    }
}
