using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Core.Model;

namespace TabimProje.Model
{
   public class Kullanici:BaseEntity
    {
        public Kullanici()
        {
            Talepler = new HashSet<Talep>();
            Degerlendirmeler = new HashSet<Degerlendirme>();
        }
        public int KullaniciId { get; set; }
        public int RoleID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public Guid? AktivasyonKodu { get; set; }
        public KullaniciRol Rol { get; set; }
        public ICollection<Talep> Talepler { get; set; }
        public ICollection<Degerlendirme> Degerlendirmeler { get; set; }

    }
}
