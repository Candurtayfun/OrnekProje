using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Core.Model;

namespace TabimProje.Model
{
  public class KullaniciRol:BaseEntity
    {
        public KullaniciRol()
        {
            Kullanici = new HashSet<Kullanici>();
        }
        public int RolId { get; set; }
        public string RolAdi { get; set; }
        public ICollection<Kullanici> Kullanici { get; set; }
    }
}
