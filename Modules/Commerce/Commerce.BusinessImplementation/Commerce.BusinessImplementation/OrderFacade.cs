using Commerce.Business;
using Commerce.Core;
using Commerce.Core.ViewModel;
using Commerce.EntityModel;
using Commerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.BusinessImplementation
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IRepository _repository;

        public OrderFacade(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public long Create(OrderView order)
        {
            return _repository.Save(new Order
            {
                CompanyId = order.CompanyId,
                ProductId = order.ProductId,
                Status = Status.Active
            }) ;
        }

        public void Delete(long id)
        {
            var order = _repository.Get<Order>(id);
            if (order != null)
            {
                order.Status = Status.Passive;
            }
            _repository.Save<Order>(order);
        }

        public void Update(OrderView order)
        {
            var entity = _repository.Get<Order>(order.Id);
            if (entity == null)
                throw new Exception("Record Not Found!");

            entity.CompanyId = order.CompanyId;
            entity.ProductId = order.ProductId;
            entity.Status = order.Status;

           

            _repository.Save(entity);

        }

        public OrderView Get(long id)
        {
            var order = _repository.Get<Order>(id);
            if (order != null)
            {
                return new OrderView
                {
                    Id = order.Id,
                    CompanyId = order.CompanyId,
                    ProductId = order.ProductId,
                    Status = order.Status
                };
            }
            else
            {
                return null;
            }
        }

        public PaginatedList<OrderView> Search(OrderSearchFilter filter, PaginationInfoView paginationInfo)
        {
            var query = _repository.Query<Order>();

            if (filter.Id > 0)
            {
                query = query.Where(x => x.Id == filter.Id);
            }
            if (filter.CompanyId > 0)
            {
                query = query.Where(x => x.CompanyId == filter.CompanyId);
            }
            if (filter.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == filter.ProductId);
            }
            if (filter.OrderStatus >= 0)
            {
                query = query.Where(x => x.OrderStatus == filter.OrderStatus);
            }
                
            query = query.Where(x => x.Status == Status.Active);



            var newQuery = query.Select(x => new OrderView
            {
                Id = x.Id,
                RefId=x.RefId,
                CompanyId = x.CompanyId,
                ProductId = x.ProductId,
                Status = x.Status,
                Description=x.Description,
                Discount=x.Discount,
                Total=x.Total,
                SetPaid=x.SetPaid,
                PaymentMethod=x.PaymentMethod,
                Currency=x.Currency
                
            });


            PaginatedList<OrderView> paginatedList = new PaginatedList<OrderView>(paginationInfo, newQuery);


            return paginatedList;

        }
    }
}
