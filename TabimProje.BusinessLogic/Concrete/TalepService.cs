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
    public class TalepService : ITalepService
    {
        ITalepDAL _talepDAL;
        public TalepService(ITalepDAL talepDAL)
        {
            _talepDAL = talepDAL;
        }
        public bool Add(Talep entity)
        {
            return _talepDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Talep deleted = _talepDAL.Get(a => a.Id == entityID);
            return _talepDAL.Delete(deleted) > 0;
        }

        public List<Talep> GetAll()
        {
            return _talepDAL.GetAll().ToList();
        }

        public List<Talep> GetAllByUser(int kullaniciID)
        {
            return _talepDAL.GetAll(a => a.KullaniciId == kullaniciID).ToList();
        }

        public Talep GetByID(int entityID)
        {
            return _talepDAL.Get(a => a.Id == entityID);
        }

        public List<Talep> GetNullByDegerlendirme()
        {
            return _talepDAL.GetAll(a=>a.Degerlendirme==null).OrderByDescending(a=>a.TalepTarihi).ToList();
        }

        public bool Update(Talep entity)
        {
            return _talepDAL.Update(entity) > 0;
        }
    }
}
