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
            Property(x => x.Status, map => map.Column("STATUS"));
            Property(x => x.CreatedBy, map => map.Column("CREATEDBY"));
            Property(x => x.CreatedByFullName, map => map.Column("CREATEDBYFULLNAME"));
            Property(x => x.CreatedDate, map => map.Column("CREATEDDATE"));
            Property(x => x.UpdatedBy, map => map.Column("UPDATEDBY"));
            Property(x => x.UpdatedByFullName, map => map.Column("UPDATEDBYFULLNAME"));
            Property(x => x.UpdatedDate, map => map.Column("UPDATEDDATE"));
            Property(x => x.Description, map => map.Column("DESCRIPTION"));
        }
    }
}
