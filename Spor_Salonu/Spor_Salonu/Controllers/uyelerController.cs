using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spor_Salonu.Models;

namespace Spor_Salonu.Controllers
{
    public class uyelerController : Controller
    {
        // GET: uyeler
        public ActionResult Index()
        {
            using (sporsalonuEntities1 db=new sporsalonuEntities1())
            {
                var model = db.giris.ToList();
                return View(model);
            }
        }

        public ActionResult uyeguncelle(giris gelenveri)
        {
            using (sporsalonuEntities1 db = new sporsalonuEntities1())
            {
                var model = db.giris.Find(gelenveri.id);
                return View(model);
            }
        }


        [HttpPost]
        public ActionResult kaydet(giris gelenveri)
        {
            using (sporsalonuEntities1 db = new sporsalonuEntities1())
            {
                var guncellenecekveri = db.giris.Find(gelenveri.id);
                db.Entry(guncellenecekveri).CurrentValues.SetValues(gelenveri);
                db.SaveChanges();
                TempData["uyeguncelle"] = " ";
                return RedirectToAction("index","uyeler");
            }
        }

        public ActionResult yeniuye()
        {
            var model = new giris();
            return View("yeniuye", model);
        }

        public ActionResult ekle(giris gelen)
        {
            if (!ModelState.IsValid)
            {
                return View("yeniuye", gelen);
            }
            using (sporsalonuEntities1 db = new sporsalonuEntities1())
            {
                if(gelen.id==0)
                {
                    db.giris.Add(gelen);
                    TempData["yeniuye"] = " ";
                }
                else
                {
                    return View();
                }
                db.SaveChanges();
                return RedirectToAction("index");
            }
        }

        public ActionResult sil(int id)
        {
            using (sporsalonuEntities1 db = new sporsalonuEntities1())
            {
                var silinecekveri = db.giris.Find(id);
                db.giris.Remove(silinecekveri);
                db.SaveChanges();
                TempData["uyesil"] = " ";
                return RedirectToAction("index");

            }
        }

    }
}