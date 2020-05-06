using Commerce.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.EntityModel
{
    public class Product:IEntity
    {
        public virtual long Id { get; set; }

        public virtual int? RefId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Image { get; set; }
        public virtual Status Status { get; set; }

        public virtual decimal? Price { get; set; }
        public virtual bool IsLast { get; set; }
        public virtual string Type { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string CreatedByFullName { get; set; }
        public virtual long CreatedDate { get; set; }  //YIL_AY_GUN_SAAT_DAKIKA_SANIYE 2 karakter for all
        public virtual string UpdatedBy { get; set; }
        public virtual string UpdatedByFullName { get; set; }
        public virtual long UpdatedDate { get; set; }
        public virtual string Description { get; set; }
        public virtual string ShortDescription { get; set; }
    }
}
