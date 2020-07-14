using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Core.Model;

namespace TabimProje.Model
{
   public class Rapor:BaseEntity
    {
        public int RaporId { get; set; }
        public int DegerlendirmeId { get; set; }
        public string Aciklama { get; set; }
        public Degerlendirme Degerlendirme { get; set; }
    }
}
