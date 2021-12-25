using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Spor_Salonu.Models;

namespace Spor_Salonu.Controllers
{
    public class beslenmekategoriController : Controller
    {
        private sporsalonuEntities1 db = new sporsalonuEntities1();

        // GET: beslenmekategori
        public ActionResult Index()
        {
            return View(db.kategori2.ToList());
        }

        // GET: beslenmekategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategori2 kategori2 = db.kategori2.Find(id);
            if (kategori2 == null)
            {
                return HttpNotFound();
            }
            return View(kategori2);
        }

        // GET: beslenmekategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: beslenmekategori/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kategoriid,kategoriad")] kategori2 kategori2)
        {
            if (ModelState.IsValid)
            {
                db.kategori2.Add(kategori2);
                db.SaveChanges();
                TempData["bkategoriekle"] = " ";
                return RedirectToAction("Index");
            }

            return View(kategori2);
        }

        // GET: beslenmekategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategori2 kategori2 = db.kategori2.Find(id);
            if (kategori2 == null)
            {
                return HttpNotFound();
            }
            return View(kategori2);
        }

        // POST: beslenmekategori/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kategoriid,kategoriad")] kategori2 kategori2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategori2).State = EntityState.Modified;
                db.SaveChanges();
                TempData["bkategoriguncelle"] = " ";
                return RedirectToAction("Index");
            }
            return View(kategori2);
        }

        // GET: beslenmekategori/Delete/5
        public ActionResult Delete(int? id)
        {
            kategori2 kategori2 = db.kategori2.Find(id);
            db.kategori2.Remove(kategori2);
            db.SaveChanges();
            TempData["bkategorisil"] = " ";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
