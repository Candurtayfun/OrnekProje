using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.BusinessLogic.Abstract;
using TabimProje.DataAccess.Abstract;
using TabimProje.Model;

namespace TabimProje.BusinessLogic.Concrete
{
    public class RaporService : IRaporService
    {
        IRaporDAL _raporDAL;
        public RaporService(IRaporDAL raporDAL)
        {
            _raporDAL = raporDAL;
        }
        public bool Add(Rapor entity)
        {
            return _raporDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Rapor deleted = _raporDAL.Get(a => a.RaporId == entityID);
            return _raporDAL.Delete(deleted) > 0;
        }

        public List<Rapor> GetAll()
        {
            return _raporDAL.GetAll().ToList();
        }

        public Rapor GetByID(int entityID)
        {
            return _raporDAL.Get(a => a.RaporId == entityID);
        }

        public bool Update(Rapor entity)
        {
            return _raporDAL.Update(entity) > 0;
        }
    }
}
