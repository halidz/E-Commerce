using Commerce.Business;
using Commerce.Core;
using Commerce.Core.ViewModel;
using Commerce.EntityModel;
using Commerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;


namespace Commerce.BusinessImplementation
{
    public class ProductFacade : IProductFacade
    {
        private readonly IRepository _repository;
        public ProductFacade(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public long Create(ProductView product)
        {
            return _repository.Save(new Commerce.EntityModel.Product
            {
                Id = product.Id,
           
                Status = Status.Active
            });
        }

        public long CreateForWP(ProductView product)
        {
            RestAPI rest = new RestAPI("https://www.ne-ararsan.com/wp-json/wc/v2/", "ck_6c2e256b3a1fc9857e78d095dadc6dcd47d7df57", "cs_d83dea91af83a7a92fc014300d9472475ef78fe6");
            WCObject wc = new WCObject(rest);
            var x = wc.Product.Add(new WooCommerceNET.WooCommerce.v2.Product
            {
                date_created = DateTime.Now,
                name = product.Name,
                regular_price = product.Price,
                type = product.Type,
                description = product.Description,
                short_description = product.ShortDescription,
                images=new List<ProductImage> {
                    new ProductImage { src=product.Image},
                }
            }) ;
            return Convert.ToInt64(x.Result.id);
        }

        public void Delete(long id)
        {
            var product = _repository.Get<EntityModel.Product>(id);
            if (product != null)
            {
                product.Status = Status.Passive;
            }
            _repository.Save<EntityModel.Product>(product);
        }

        public ProductView Get(long id)
        {
            var order = _repository.Get<EntityModel.Product>(id);
            if (order != null)
            {
                return new ProductView
                {
                    Id = order.Id,
                    Status = order.Status
                };
            }
            else
            {
                return null;
            }
        }

        public PaginatedList<ProductView> Search(ProductSearchFilter filter, PaginationInfoView paginationInfo)
        {
            var query = _repository.Query<EntityModel.Product>();

            if (filter.Id > 0)
            {
                query = query.Where(x => x.Id == filter.Id);
            }
            if (!String.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Name.Contains(filter.Name));
            }

            query = query.Where(x => x.Status == Status.Active);

            var newQuery = query.Select(x => new ProductView
            {
                Id = x.Id,
                Name=x.Name,
                Status = x.Status,
                Price=x.Price,
                RefId=x.RefId,
                Image=x.Image,
                Description=x.Description,
                Type=x.Type

            });


            PaginatedList<ProductView> paginatedList = new PaginatedList<ProductView>(paginationInfo, newQuery);


            return paginatedList;
        }

        public void Update(ProductView product)
        {
            var entity = _repository.Get<EntityModel.Product>(product.Id);
            if (entity == null)
                throw new Exception("Record Not Found!");        
            entity.Status = product.Status;
            _repository.Save(entity);
        }
    }
}
