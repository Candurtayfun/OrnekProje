using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Model;

namespace TabimProje.DataAccess.Concrete.EntityFramework.Mapping
{
    class RaporMapping : EntityTypeConfiguration<Rapor>
    {
        public RaporMapping()
        {
            HasKey(i => i.RaporId);
            Property(i => i.Aciklama).HasMaxLength(500).IsRequired();
            HasRequired(i => i.Degerlendirme).WithMany(i => i.Raporlar).HasForeignKey(i => i.DegerlendirmeId).WillCascadeOnDelete(false);
        }
    }
}
