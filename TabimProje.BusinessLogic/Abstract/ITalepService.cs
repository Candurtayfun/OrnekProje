﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Model;

namespace TabimProje.BusinessLogic.Abstract
{
   public interface ITalepService:IBaseService<Talep>
    {
        List<Talep> GetAllByUser(int kullaniciID);
        List<Talep> GetNullByDegerlendirme();
    }
}
