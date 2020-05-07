using Commerce.EntityModel;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.NhMapping
{
    public class BillingMap :ClassMapping<Billing>
    {
        public BillingMap()
        {
            Table("COMMERCE_BILLING");

            Id(x => x.Id, map =>
            {
                map.Column("ID");
                map.Generator(Generators.Native);
            });
            Property(x => x.First_name, map => map.Column("FIRSTNAME"));
            Property(x => x.Last_name, map => map.Column("LASTNAME"));
            Property(x => x.Phone, map => map.Column("PHONE"));
            Property(x => x.Email, map => map.Column("EMAIL"));
            Property(x => x.Address_1, map => map.Column("ADDRESS1"));
            Property(x => x.Address_2, map => map.Column("ADDRESS2"));
            Property(x => x.City, map => map.Column("CITY"));
            Property(x => x.Country, map => map.Column("COUNTRY"));
            Property(x => x.Postcode, map => map.Column("POSTCODE"));
            Property(x => x.State, map => map.Column("STATE"));
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
