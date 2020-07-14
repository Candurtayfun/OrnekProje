using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Model;
using TabimProje.UI.MVC.Models;

namespace TabimProje.Common
{
   public class MailHelper
    {
        public static bool SendMail(Kullanici user)
        {
            try
            {
                //Bizim mail adresimizi tutan instance(maili gönderecek olan adres)
                MailAddress fromAddress = new MailAddress("anindakapindaankara@gmail.com");
                //Gönderilecek mail adresinin instance(maili alacak adres)
                MailAddress toAddress = new MailAddress(user.Mail);
              
                //Gönderilecek olan mail ile ilgili bilgiler
                MailMessage message = new MailMessage();
                //Gidecek mailin başlığı
                message.Subject = "Tabim Proje Üyelik Daveti";
                //Gidecek mailin içeriği. Eğer body içerisinde html tagleri kullanıldıysa, direk string olarak algılanır. Bunun html olarak algılanması için IsBodyHtml propertysi true yapılır.
                message.Body = $"<p>Tabim Proje sistemine davet edildiniz. Kullanıcı hesabınız aşagidaki bilgilerle oluşturulmuştur. Linke tıklayarak giriş yapabilirsiniz.</p><p>Ad : {user.Adi}</p><p>Soyad : {user.Soyadi}</p><p>Mail : {user.Mail}</p><p>{user.Sifre}</p><p><a href='http://localhost:64027/Account/Activate?code={user.AktivasyonKodu}'>Giriş yapmak için tıklayın</a></p>";
                message.IsBodyHtml = true;
                //mail kimden gönderilecek
                message.From = fromAddress;
                //mail kime gidecek
                message.To.Add(toAddress);

                //SMTP protokolü mail gönderme protokolüdür. Bir mail gönderebilmek için sunucu ile haberleşilmesi gerekir.
                SmtpClient smtp = new SmtpClient();
                //smtp'nin host adresi.
                smtp.Host = "smtp.gmail.com";
                //her yerde çalışan port numarası
                smtp.Port = 587;
                //bizim kim olduğumuz bilgisi. Mail adresi ve şifresi
                smtp.Credentials = new NetworkCredential("anindakapindaankara@gmail.com", "bilgeadam");
                //smtp'nin de güvenlik sertikasıyla gitmesi gerekir.
                smtp.EnableSsl = true;

                //gönderilecek mail Send metodu içerisine verilir.
                smtp.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool SendMailUser(MailViewModel mailmodel)
        {
            try
            {
                MailAddress fromAddress = new MailAddress("anindakapindaankara@gmail.com");
                MailAddress toAddress = new MailAddress(mailmodel.Mail);
                
                MailMessage message = new MailMessage();
                message.Subject = "Tabim Proje Degerlendirme Sonucu";
                message.Body = $"<p>Tabim Proje sistemindesiniz.<br>Değerlendirmeniz yapılmıştır.<br> Degerlendirme sonucu : </p><p>{mailmodel.DegerlendirmeSonucu}</p><p> Degerlendirme sonucu : {mailmodel.DegerlendirmeZamani}</p>";
                message.IsBodyHtml = true;
                message.From = fromAddress;
                message.To.Add(toAddress);

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("anindakapindaankara@gmail.com", "bilgeadam");
                smtp.EnableSsl = true;

                smtp.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
