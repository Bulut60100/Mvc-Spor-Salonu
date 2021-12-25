using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spor_Salonu.Models;
using System.Web.Security;

namespace Spor_Salonu.Controllers
{
    public class anasayfaController : Controller
    {
        // GET: anasayfa
        sporsalonuEntities1 db = new sporsalonuEntities1();
        public ActionResult index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult index(giris t)
        {

            var bilgiler = db.giris.FirstOrDefault(x => x.kadi == t.kadi && x.sifre == t.sifre && x.yetki == t.yetki);
            if (bilgiler == null)
            {
                ViewBag.hata = "kullanıcı adı veya şifre hatalı";
                return View("index");
            }
            if (bilgiler.yetki != null)
            {
                return RedirectToAction("index", "admin");
            }
            if (bilgiler.yetki == null)
            {
                return RedirectToAction("index", "kullanici");
            }
            else
            {
                return View();
            }


        }


        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index");
        }

    }
}