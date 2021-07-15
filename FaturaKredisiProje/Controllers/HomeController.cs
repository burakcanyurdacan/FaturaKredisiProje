using FaturaKredisiProje.Models;
using FaturaKredisiProje.MyMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaturaKredisiProje.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult FormPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult Test(Mail mail)
        {
            string sonuc;
            if (string.IsNullOrWhiteSpace(mail.AdSoyad) || string.IsNullOrWhiteSpace(mail.Sehir) || string.IsNullOrWhiteSpace(mail.TelefonHat) || string.IsNullOrWhiteSpace(mail.Telefon) || mail.Dogumyil == 0)
            {
                sonuc = "-1";
            }
            else
            {
                EpostaGonder eposta = new EpostaGonder();
                sonuc = eposta.Gonder(mail);
            }
            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }
    }
}