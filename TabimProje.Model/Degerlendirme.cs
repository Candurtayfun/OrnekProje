using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Core.Model;

namespace TabimProje.Model
{
   public class Degerlendirme:BaseEntity
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public DateTime DegerlendirmeZamani { get; set; }
        public string DegerlendirmeSonucu { get; set; }
        public string Aciklama { get; set; }
        public Kullanici Kullanici { get; set; }
        public Talep Talep { get; set; }
        public ICollection<Rapor> Raporlar { get; set; }

    }
}
