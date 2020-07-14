using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Core.DataAccess;
using TabimProje.Model;

namespace TabimProje.DataAccess.Abstract
{
    public interface ITalepDAL : IRepository<Talep>
    {//Irepository özelliştirilir.. nasıl olduğu belli oldu artık
    }
}
