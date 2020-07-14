using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TabimProje.Core.Model;

namespace TabimProje.UI.MVC.Models
{
    public class MailViewModel:BaseEntity
    {
        public int RolId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        public string Telefon { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
        public int Id { get; set; }
        public DateTime DegerlendirmeZamani { get; set; }
        public string DegerlendirmeSonucu { get; set; }
        public string Aciklama { get; set; }
    }
}