using Commerce.EntityModel;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Commerce.NhMapping
{
    public class OrderMap : ClassMapping<Order>
    {
        public OrderMap()
        {
            Table("COMMERCE_ORDER");

            Id(x => x.Id, map =>
             {
                 map.Column("ID");
                 map.Generator(Generators.Native);
             });

            Property(x => x.RefId, map => map.Column("REFID"));
            Property(x => x.ProductId, map => map.Column("PRODUCTID"));
            Property(x => x.CompanyId, map => map.Column("COMPANYID"));
            Property(x => x.IsLast, map => map.Column("ISLAST"));
            Property(x => x.Currency, map => map.Column("CURRENCY"));
            Property(x => x.PaymentMethod, map => map.Column("PAYMENTMETHOD"));           
            Property(x => x.CustomerNote, map => map.Column("CUSTOMERNOTE"));
            Property(x => x.SetPaid, map => map.Column("ISPAID"));
            Property(x => x.Discount, map => map.Column("DISCOUNT"));
            Property(x => x.ShippingTotal, map => map.Column("SHIPPINGTOPLAM"));
            Property(x => x.Total, map => map.Column("TOPLAM"));
            Property(x => x.OrderStatus, map => map.Column("ORDERSTATUS"));
            Property(x => x.Description, map => map.Column("DESCRIPTION"));
            Property(x => x.Status, map => map.Column("STATUS"));
            Property(x => x.CreatedBy, map => map.Column("CREATEDBY"));
            Property(x => x.CreatedByFullName, map => map.Column("CREATEDBYFULLNAME"));
            Property(x => x.CreatedDate, map => map.Column("CREATEDDATE"));
            Property(x => x.UpdatedBy, map => map.Column("UPDATEDBY"));
            Property(x => x.UpdatedByFullName, map => map.Column("UPDATEDBYFULLNAME"));
            Property(x => x.UpdatedDate, map => map.Column("UPDATEDDATE"));
            
        }
    }
}
