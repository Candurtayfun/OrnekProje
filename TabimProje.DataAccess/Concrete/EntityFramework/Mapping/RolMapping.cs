using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Model;

namespace TabimProje.DataAccess.Concrete.EntityFramework.Mapping
{
    class RolMapping : EntityTypeConfiguration<KullaniciRol>
    {
        public RolMapping()
        {
            HasKey(i => i.RolId);
            Property(i => i.RolAdi).HasMaxLength(30);
        }
    }
}
