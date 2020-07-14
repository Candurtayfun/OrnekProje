using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.DataAccess.Concrete.EntityFramework.Mapping;
using TabimProje.Model;

namespace TabimProje.DataAccess.Concrete.EntityFramework
{
   public class TabimProjeDBContext : DbContext
    {
        public TabimProjeDBContext():base("name=TabimProje")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<KullaniciRol> KullaniciRoller { get; set; }
        public DbSet<Talep> Talepler { get; set; }
        public DbSet<Degerlendirme> Degerlendirmeler { get; set; }
        public DbSet<Rapor> Raporlar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KullaniciMapping());
            modelBuilder.Configurations.Add(new RolMapping());
            modelBuilder.Configurations.Add(new RaporMapping());
            modelBuilder.Configurations.Add(new DegerlendirmeMapping());
            modelBuilder.Configurations.Add(new TalepMapping());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
