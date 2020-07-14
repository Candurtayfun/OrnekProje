using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TabimProje.BusinessLogic.Abstract;
using TabimProje.Common;
using TabimProje.Model;
using TabimProje.UI.MVC.Filters;
using TabimProje.UI.MVC.Models;

namespace TabimProje.UI.MVC.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ITalepService _talepService;
        IDegerlendirmeService _degerlendirmeService;
        IKullaniciService _kullaniciService;
       
        public AdminController(ITalepService talepService, IDegerlendirmeService degerlendirmeService, IKullaniciService kullaniciService)
        {
            _talepService = talepService;
            _degerlendirmeService = degerlendirmeService;
            _kullaniciService = kullaniciService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Talep()
        {    
            return View(_talepService.GetNullByDegerlendirme());
        }
        //Session dan kullanıcı getir, degerlendirmeyi güncelle, kullanıcıya mail gönder,talep getir
        public ActionResult TalepDegerlendir(int id)
        {
            Talep t = _talepService.GetByID(id);
            return View(t);
        }
        [HttpPost]
        public ActionResult TalepDegerlendir(Talep talep)
        {//Talebi güncelleyip degerlendirme yapılır
           Kullanici userkullanici = ((Kullanici)Session["kullanici"]);
            
            Degerlendirme degerlendirme = new Degerlendirme();
            degerlendirme.Id = talep.Id;
            degerlendirme.KullaniciId = userkullanici.KullaniciId;
            degerlendirme.DegerlendirmeSonucu = talep.Degerlendirme.DegerlendirmeSonucu;
            degerlendirme.DegerlendirmeZamani = talep.Degerlendirme.DegerlendirmeZamani;
            degerlendirme.Aciklama = talep.Degerlendirme.Aciklama;
            _degerlendirmeService.Add(degerlendirme);
            Kullanici user = new Kullanici();
            user.Adi = userkullanici.Adi;
            user.Soyadi = userkullanici.Soyadi;
            user.Mail = userkullanici.Mail;
            user.Telefon = userkullanici.Telefon;
            user.Sifre = userkullanici.Sifre;
            user.IsActive = true;
            user.RoleID = 2;
            MailViewModel mailmodel = new MailViewModel();
            mailmodel.DegerlendirmeSonucu = degerlendirme.DegerlendirmeSonucu;
            mailmodel.DegerlendirmeZamani = degerlendirme.DegerlendirmeZamani;
            mailmodel.Mail = user.Mail;
            try
            {            
                if (mailmodel != null)
                {
                    MailHelper.SendMailUser(mailmodel);
                }

                return RedirectToAction("Rapor");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }
        public ActionResult Rapor()
        {     
            return View(_degerlendirmeService.GetAll());
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }
        public ActionResult TalepSil(int id, string ad)
        {
            Talep talep = _talepService.GetByID(id);
            return View(talep);
        }
        [HttpPost]
        public ActionResult TalepSil(int id)
        {
            _talepService.Delete(id);
            return RedirectToAction("Talep");
        }

    }
}