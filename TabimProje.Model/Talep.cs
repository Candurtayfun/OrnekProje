using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Core.Model;

namespace TabimProje.Model
{
   public class Talep:BaseEntity
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Belge { get; set; }
        public string Yorum { get; set; }
        public DateTime TalepTarihi { get; set; }
        public Kullanici Kullanici { get; set; }
        public  Degerlendirme Degerlendirme { get; set; }
    }
}
