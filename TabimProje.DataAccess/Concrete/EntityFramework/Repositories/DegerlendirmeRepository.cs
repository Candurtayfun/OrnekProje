﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Core.DataAccess.EntityFramework;
using TabimProje.DataAccess.Abstract;
using TabimProje.Model;

namespace TabimProje.DataAccess.Concrete.EntityFramework.Repositories
{
  public  class DegerlendirmeRepository : EFRepositoryBase<Degerlendirme, TabimProjeDBContext>, IDegerlendirmeDAL
    {
        //Generic oldukları için, bir tip verip özellik kazandırdık, CRUD işlemlerini kazandırdık
    }
}
