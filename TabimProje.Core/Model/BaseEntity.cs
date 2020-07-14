using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabimProje.Core.Model
{
   public abstract class BaseEntity
    {//Genel Kısıt, tüm entitylere kalıtım olarak verilir. Hepsinin aynı temelden gelmesi sağlanır
        public BaseEntity()
        {
            IsActive = true;
            CreatedDate = DateTime.Now;
        }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
