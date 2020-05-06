using Commerce.SystemManagement.EntityModel;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace Commerce.SystemManagement.NhMapping
{
    public class TokenMap :ClassMapping<Token>
    {
        public TokenMap()
        {
            Table("SYM_TOKEN");
            Id(x => x.Id, map =>
            {
                map.Column("TID");
                map.Generator(Generators.Native);
            });
            Property(x => x.TokenId, map => map.Column("TOKEN"));
            Property(x => x.UserName, map => map.Column("USERNAME"));
            Property(x => x.UserID, map => map.Column("USERID"));
            Property(x => x.ExpireDate, map => map.Column("EXPIREDATE"));
            Property(x => x.CreateDate, map => map.Column("CREATEDATE"));
        }
    }
}
