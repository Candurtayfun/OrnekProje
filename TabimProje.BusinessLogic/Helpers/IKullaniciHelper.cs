using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabimProje.BusinessLogic.Helpers
{
    interface IKullaniciHelper
    {//okunabilirlik arttırmak için yaptık. başka kişilerinde kullanacağını düşünürsek..
        //Şifre kontrolü de yapılabilir
        void CheckMail(string mail);
    }
}
