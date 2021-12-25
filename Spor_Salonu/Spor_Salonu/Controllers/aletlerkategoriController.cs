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
    public class aletlerkategoriController : Controller
    {
        private sporsalonuEntities1 db = new sporsalonuEntities1();

        // GET: aletlerkategori
        public ActionResult Index()
        {
            return View(db.kategori.ToList());
        }

        // GET: aletlerkategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategori kategori = db.kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // GET: aletlerkategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: aletlerkategori/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kategorid,kategoriad")] kategori kategori)
        {
            if (ModelState.IsValid)
            {
                db.kategori.Add(kategori);
                db.SaveChanges();
                TempData["kategoriekle"] = " ";
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        // GET: aletlerkategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategori kategori = db.kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // POST: aletlerkategori/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kategorid,kategoriad")] kategori kategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                TempData["kategoriguncelle"] = " ";
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        // GET: aletlerkategori/Delete/5
        public ActionResult Delete(int? id)
        {
            kategori kategori = db.kategori.Find(id);
            db.kategori.Remove(kategori);
            db.SaveChanges();
            TempData["kategorisil"] = " ";
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
