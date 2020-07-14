using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TabimProje.BusinessLogic.Abstract;
using TabimProje.Model;
using TabimProje.UI.MVC.Filters;

namespace TabimProje.UI.MVC.Controllers
{
    [CustomAuthorize(Roles = "Kullanici")]
    public class HomeController : Controller
    {
        ITalepService _talepService;
        IKullaniciService _kullaniciService;
        int userid;
        public HomeController(ITalepService talepService, IKullaniciService kullaniciService)
        {
            _talepService = talepService;
            _kullaniciService = kullaniciService;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Menu()
        {
            userid = ((Kullanici)Session["kullanici"]).KullaniciId;
            return PartialView(_kullaniciService.GetByID(userid));
        }
        public ActionResult TalepEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TalepEkle(Talep t)
        {
            
            int kullaniciId = ((Kullanici)Session["kullanici"]).KullaniciId;
            t.KullaniciId = kullaniciId;
            _talepService.Add(t);
            return View();
        }

        public ActionResult Hesabim()
        {
            int userid = ((Kullanici)Session["kullanici"]).KullaniciId;
            return View(_kullaniciService.GetByID(userid));
        }
        [HttpPost]
        public ActionResult Hesabim(Kullanici kullanici)
        {
            Kullanici updated = _kullaniciService.GetByID(kullanici.KullaniciId);
            updated.Adi = kullanici.Adi;
            updated.Soyadi = kullanici.Soyadi;
            updated.Mail = kullanici.Mail;
            updated.Sifre = kullanici.Sifre;
            updated.Telefon = kullanici.Telefon;
            _kullaniciService.Update(updated);
            return View(_kullaniciService.GetByID(kullanici.KullaniciId));
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Talep()
        {
           int userId = ((Kullanici)Session["kullanici"]).KullaniciId;
            List<Talep> t=_talepService.GetAllByUser(userId);
            return View(t);
        }
    }
}