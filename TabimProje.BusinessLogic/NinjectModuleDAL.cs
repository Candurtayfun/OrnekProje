using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.DataAccess.Abstract;
using TabimProje.DataAccess.Concrete.EntityFramework.Repositories;

namespace TabimProje.BusinessLogic
{
    public class NinjectModuleDAL : NinjectModule
    {
        public override void Load()
        {
            //Bind metodu ile hangi soyut nesneden instance istendiğini, To metodu ile de hangi somut nesneyi döneceğini söylüyoruz. 
            this.Bind<IKullaniciDAL>().To<KullaniciRepository>();
            this.Bind<IKullaniciRolDAL>().To<KullaniciRoleRepository>();
            this.Bind<ITalepDAL>().To<TalepRepository>();
            this.Bind<IRaporDAL>().To<RaporRepository>();
            this.Bind<IDegerlendirmeDAL>().To<DegerlendirmeRepository>();
        }
    }
}
