﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.BusinessLogic.Abstract;
using TabimProje.DataAccess.Abstract;
using TabimProje.Model;

namespace TabimProje.BusinessLogic.Concrete
{
    public class KullaniciRolService : IKullaniciRolService
    {
        IKullaniciRolDAL _kullaniciRolDAL;
        public KullaniciRolService(IKullaniciRolDAL rolDAL)
        {
            _kullaniciRolDAL = rolDAL;
        }
        public bool Add(KullaniciRol entity)
        {//İşlem başarılı mı değil mi?
            return _kullaniciRolDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            KullaniciRol deleted = _kullaniciRolDAL.Get(a => a.RolId == entityID);
            return _kullaniciRolDAL.Delete(deleted) > 0;
        }

        public List<KullaniciRol> GetAll()
        {
            return _kullaniciRolDAL.GetAll().ToList();
        }

        public KullaniciRol GetByID(int entityID)
        {
            return _kullaniciRolDAL.Get(a => a.RolId == entityID);
        }

        public KullaniciRol GetRoleByName(string ad)
        {
            return _kullaniciRolDAL.Get(a => a.RolAdi == ad);
        }

        public bool Update(KullaniciRol entity)
        {
            return _kullaniciRolDAL.Update(entity) > 0;
        }
    }
}
