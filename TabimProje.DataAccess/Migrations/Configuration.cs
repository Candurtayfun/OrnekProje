namespace TabimProje.DataAccess.Migrations
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TabimProje.DataAccess.Concrete.EntityFramework.TabimProjeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

        }

        protected override void Seed(TabimProje.DataAccess.Concrete.EntityFramework.TabimProjeDBContext context)
        {
            List<KullaniciRol> roller = new List<KullaniciRol>() {
                new KullaniciRol(){ RolAdi = "Admin" },
                new KullaniciRol(){ RolAdi = "Kullanici" },
            };

            context.KullaniciRoller.AddRange(roller);

            context.SaveChanges();
        }
    }
}
