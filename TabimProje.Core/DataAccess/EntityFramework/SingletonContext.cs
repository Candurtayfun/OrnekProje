using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabimProje.Core.DataAccess.EntityFramework
{
   class SingletonContext<TContext> where TContext : DbContext, new()
    {//tek bir işlem yapmamızı UPDATE yapıyorum, tekrar instance etmemize gerek kalmaz, bir kere instance edilir.
        private static TContext context;
        private SingletonContext()
        {
            //Dışardan erişilmesini kısıtlayarak güvenliği sağladık.
        }
       internal static TContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new TContext();
                }
                return context;
            }
        }
    }
}
