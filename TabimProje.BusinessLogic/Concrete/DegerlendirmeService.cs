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
    public class DegerlendirmeService : IDegerlendirmeService
    {
        IDegerlendirmeDAL _degerlendirmeDAL;
        public DegerlendirmeService(IDegerlendirmeDAL degerlendirmeDAL)
        {
            _degerlendirmeDAL = degerlendirmeDAL;
        }
        public bool Add(Degerlendirme entity)
        {
            return _degerlendirmeDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Degerlendirme deleted = _degerlendirmeDAL.Get(a => a.Id == entityID);
            return _degerlendirmeDAL.Delete(deleted) > 0;
        }

        public List<Degerlendirme> GetAll()
        {
            return _degerlendirmeDAL.GetAll().ToList();
        }

        public List<Degerlendirme> GetAllByUser(int kullaniciID)
        {
            return _degerlendirmeDAL.GetAll(a => a.KullaniciId == kullaniciID).ToList();
        }

        public Degerlendirme GetByID(int entityID)
        {
            return _degerlendirmeDAL.Get(a => a.Id == entityID);
        }

        public bool Update(Degerlendirme entity)
        {
            return _degerlendirmeDAL.Update(entity) > 0;
        }
    }
}
