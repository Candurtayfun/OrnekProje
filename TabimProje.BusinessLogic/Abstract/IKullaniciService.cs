using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Model;

namespace TabimProje.BusinessLogic.Abstract
{
   public interface IKullaniciService:IBaseService<Kullanici>
    {
        Kullanici GetUserByLogin(string mail, string sifre);
        Kullanici GetUserByCode(Guid code);
        List<Kullanici> GetAllByUyeID(int id);
    }
}
