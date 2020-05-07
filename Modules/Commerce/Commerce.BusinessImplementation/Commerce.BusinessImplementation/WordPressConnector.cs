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
using Commerce.Commerce.Core;

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
            long billingId;
            long shippingId;
            var orders = wc.Order.GetAll();
            orders.Wait();
            var count = orders.Result.Count;
            var query = _repository.Query<EntityModel.Order>();
            var list = query.ToList();     //Tolist yerine query result count kullanılabilir.
            StatusMapper statusMapper = new StatusMapper();
            if (list.Count == 0)
            {
                var orderInstance = orders.Result[0];
                 billingId = _repository.Save<Billing>(new Billing
                {
                    First_name = orderInstance.billing.first_name,
                    Last_name = orderInstance.billing.last_name,
                    Address_1 = orderInstance.billing.address_1,
                    Address_2 = orderInstance.billing.address_2,
                    City = orderInstance.billing.city,
                    Country = orderInstance.billing.country,
                    Company = orderInstance.billing.company,
                    Email = orderInstance.billing.email,
                    Phone = orderInstance.billing.phone,
                    Postcode = orderInstance.billing.postcode,
                    State = orderInstance.billing.state

                });
                 shippingId = _repository.Save<Shipping>(new Shipping {
                    First_name = orderInstance.shipping.first_name,
                    Last_name = orderInstance.shipping.last_name,
                    Address_1 = orderInstance.shipping.address_1,
                    Address_2 = orderInstance.shipping.address_2,
                    City = orderInstance.shipping.city,
                    Country = orderInstance.shipping.country,
                    Company = orderInstance.shipping.company,  
                    Postcode = orderInstance.shipping.postcode,
                    State = orderInstance.shipping.state
                });
                _repository.Save<EntityModel.Order>(new EntityModel.Order {
                    BillingId =billingId,ShippingId=shippingId,
                    RefId = Convert.ToInt64(orderInstance.id),
                    CreatedDate = DateTime.Now.ToDateTime(),
                    IsLast = true,
                    Status = Status.Active,
                    Total= orderInstance.total,
                    Currency=orderInstance.currency,
                    CustomerIpAddress=orderInstance.customer_ip_address,
                    Discount=orderInstance.discount_total,
                    SetPaid=orderInstance.set_paid,
                    ShippingTotal=orderInstance.shipping_total,
                    PaymentMethod=orderInstance.payment_method,
                    OrderStatus=statusMapper.Map(orderInstance.status)


                });
                for (int i = 1; i < count; i++)
                {
                    orderInstance = orders.Result[i];
                    billingId = _repository.Save<Billing>(new Billing
                    {
                        First_name = orderInstance.billing.first_name,
                        Last_name = orderInstance.billing.last_name,
                        Address_1 = orderInstance.billing.address_1,
                        Address_2 = orderInstance.billing.address_2,
                        City = orderInstance.billing.city,
                        Country = orderInstance.billing.country,
                        Company = orderInstance.billing.company,
                        Email = orderInstance.billing.email,
                        Phone = orderInstance.billing.phone,
                        Postcode = orderInstance.billing.postcode,
                        State = orderInstance.billing.state

                    });
                    shippingId = _repository.Save<Shipping>(new Shipping
                    {
                        First_name = orderInstance.shipping.first_name,
                        Last_name = orderInstance.shipping.last_name,
                        Address_1 = orderInstance.shipping.address_1,
                        Address_2 = orderInstance.shipping.address_2,
                        City = orderInstance.shipping.city,
                        Country = orderInstance.shipping.country,
                        Company = orderInstance.shipping.company,
                        Postcode = orderInstance.shipping.postcode,
                        State = orderInstance.shipping.state
                    });
                    _repository.Save<EntityModel.Order>(new EntityModel.Order {
                        BillingId = billingId,
                        ShippingId = shippingId,
                        RefId = Convert.ToInt64(orderInstance.id),
                        CreatedDate = DateTime.Now.ToDateTime(),
                        IsLast = false,
                        Status = Status.Active,
                        Total = orderInstance.total,
                        Currency = orderInstance.currency,
                        CustomerIpAddress = orderInstance.customer_ip_address,
                        Discount = orderInstance.discount_total,
                        SetPaid = orderInstance.set_paid,
                        ShippingTotal = orderInstance.shipping_total,
                        PaymentMethod = orderInstance.payment_method,
                        OrderStatus = statusMapper.Map(orderInstance.status)
                    });
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
                        billingId = _repository.Save<Billing>(new Billing
                        {
                            First_name = orderInstance.billing.first_name,
                            Last_name = orderInstance.billing.last_name,
                            Address_1 = orderInstance.billing.address_1,
                            Address_2 = orderInstance.billing.address_2,
                            City = orderInstance.billing.city,
                            Country = orderInstance.billing.country,
                            Company = orderInstance.billing.company,
                            Email = orderInstance.billing.email,
                            Phone = orderInstance.billing.phone,
                            Postcode = orderInstance.billing.postcode,
                            State = orderInstance.billing.state

                        });
                        shippingId = _repository.Save<Shipping>(new Shipping
                        {
                            First_name = orderInstance.shipping.first_name,
                            Last_name = orderInstance.shipping.last_name,
                            Address_1 = orderInstance.shipping.address_1,
                            Address_2 = orderInstance.shipping.address_2,
                            City = orderInstance.shipping.city,
                            Country = orderInstance.shipping.country,
                            Company = orderInstance.shipping.company,
                            Postcode = orderInstance.shipping.postcode,
                            State = orderInstance.shipping.state
                        });
                        _repository.Save<EntityModel.Order>(new EntityModel.Order {
                            BillingId = billingId,
                            ShippingId = shippingId,
                            RefId = Convert.ToInt64(orderInstance.id),
                            CreatedDate = DateTime.Now.ToDateTime(),
                            IsLast = false ,
                            Status =Status.Active,
                            Total = orderInstance.total,
                            Currency = orderInstance.currency,
                            CustomerIpAddress = orderInstance.customer_ip_address,
                            Discount = orderInstance.discount_total,
                            SetPaid = orderInstance.set_paid,
                            ShippingTotal = orderInstance.shipping_total,
                            PaymentMethod = orderInstance.payment_method,
                            OrderStatus = statusMapper.Map(orderInstance.status)
                        });
                    }
                    counter = counter + 1;
                    orderInstance = orders.Result[0];
                    billingId = _repository.Save<Billing>(new Billing
                    {
                        First_name = orderInstance.billing.first_name,
                        Last_name = orderInstance.billing.last_name,
                        Address_1 = orderInstance.billing.address_1,
                        Address_2 = orderInstance.billing.address_2,
                        City = orderInstance.billing.city,
                        Country = orderInstance.billing.country,
                        Company = orderInstance.billing.company,
                        Email = orderInstance.billing.email,
                        Phone = orderInstance.billing.phone,
                        Postcode = orderInstance.billing.postcode,
                        State = orderInstance.billing.state

                    });
                    shippingId = _repository.Save<Shipping>(new Shipping
                    {
                        First_name = orderInstance.shipping.first_name,
                        Last_name = orderInstance.shipping.last_name,
                        Address_1 = orderInstance.shipping.address_1,
                        Address_2 = orderInstance.shipping.address_2,
                        City = orderInstance.shipping.city,
                        Country = orderInstance.shipping.country,
                        Company = orderInstance.shipping.company,
                        Postcode = orderInstance.shipping.postcode,
                        State = orderInstance.shipping.state
                    });
                    _repository.Save<EntityModel.Order>(new EntityModel.Order {
                        BillingId = billingId,
                        ShippingId = shippingId,
                        RefId = Convert.ToInt64(orderInstance.id),
                        CreatedDate = DateTime.Now.ToDateTime(),
                        IsLast = true,
                        Status = Status.Active,
                        Total = orderInstance.total,
                        Currency = orderInstance.currency,
                        CustomerIpAddress = orderInstance.customer_ip_address,
                        Discount = orderInstance.discount_total,
                        SetPaid = orderInstance.set_paid,
                        ShippingTotal = orderInstance.shipping_total,
                        PaymentMethod = orderInstance.payment_method,
                        OrderStatus = statusMapper.Map(orderInstance.status)
                    });

                    lastOrder.IsLast = false;
                    _repository.Save<EntityModel.Order>(lastOrder);

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
        public int QueryProduct()
        {
            RestAPI rest = new RestAPI("https://www.ne-ararsan.com/wp-json/wc/v2/", "ck_6c2e256b3a1fc9857e78d095dadc6dcd47d7df57", "cs_d83dea91af83a7a92fc014300d9472475ef78fe6");
            WCObject wc = new WCObject(rest);
          
            var products = wc.Product.GetAll();
            products.Wait();
            var counter = 0;
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
                counter = count;
                return counter;
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
                    return 0;

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
                        counter = counter + 1;
                        _repository.Save<EntityModel.Product>(new EntityModel.Product
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
                    counter = counter + 1;
                    _repository.Save<EntityModel.Product>(new EntityModel.Product
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
                    _repository.Save<EntityModel.Product>(lastOrder);
                    return counter;
                }
            }

        }
    }
}
