using Commerce.SystemManagement.EntityModel;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace Commerce.SystemManagement.NhMapping
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("SYM_USER");
            Id(x => x.Id,
                map =>
                {
                    map.Column("USERID");
                    map.Generator(Generators.Native);
                });
            Property(x => x.FirstName, map => map.Column("FIRSTNAME"));
            Property(x => x.LastName, map => map.Column("LASTNAME"));
            Property(x => x.UserName, map =>map.Column("USERNAME"));
            Property(x => x.Password, map =>map.Column("PASSWORD"));
            Property(x => x.Status, map =>map.Column("STATUS"));
            Property(x => x.Email, map =>map.Column("EMAILADDRESS"));
            Bag(x => x.Roles, map =>
            {
                map.Key(k =>
                {
                    k.Column("USERID");
                });
                map.Cascade(Cascade.None);
                map.Table("SYM_USER_ROLE");
                map.Lazy(CollectionLazy.Lazy);
            },
            ce => ce.ManyToMany(l =>
            {
                l.Column("ROLEID");
                l.Class(typeof(Role));
            }));
        }
    }
}
