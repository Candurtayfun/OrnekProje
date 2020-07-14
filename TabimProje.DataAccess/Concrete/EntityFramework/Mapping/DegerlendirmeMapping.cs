using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Model;

namespace TabimProje.DataAccess.Concrete.EntityFramework.Mapping
{
    class DegerlendirmeMapping : EntityTypeConfiguration<Degerlendirme>
    {
        public DegerlendirmeMapping()
        {
            HasKey(i => i.Id).HasRequired(i=>i.Talep).WithRequiredDependent(i=>i.Degerlendirme);
            Property(i => i.DegerlendirmeSonucu).HasMaxLength(30).IsRequired();
            Property(i => i.DegerlendirmeZamani).IsRequired();
            Property(i => i.Aciklama).HasMaxLength(500).IsRequired();
            HasRequired(i => i.Kullanici).WithMany(i => i.Degerlendirmeler).HasForeignKey(i => i.KullaniciId).WillCascadeOnDelete(false);
           
        }
    }
}
