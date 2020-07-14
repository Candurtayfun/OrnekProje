using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Model;

namespace TabimProje.DataAccess.Concrete.EntityFramework.Mapping
{
    class TalepMapping : EntityTypeConfiguration<Talep>
    {
        public TalepMapping()
        {
            HasKey(i => i.Id).HasRequired(i => i.Degerlendirme).WithRequiredPrincipal(i => i.Talep);
            Property(i => i.Adi).HasMaxLength(20).IsRequired();
            Property(i => i.Soyadi).HasMaxLength(30).IsRequired();
            Property(i => i.Belge).HasMaxLength(500).IsRequired();
            Property(i => i.Yorum).HasMaxLength(500).IsRequired();
            Property(i => i.TalepTarihi).IsRequired();
            HasRequired(i => i.Kullanici).WithMany(i => i.Talepler).HasForeignKey(i => i.KullaniciId).WillCascadeOnDelete(false);
        }
    }
}
