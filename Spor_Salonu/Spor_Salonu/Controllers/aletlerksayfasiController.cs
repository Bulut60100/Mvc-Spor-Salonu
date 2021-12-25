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
    public class aletlerksayfasiController : Controller
    {
        private sporsalonuEntities1 db = new sporsalonuEntities1();

        // GET: aletlerksayfasi
        public ActionResult Index()
        {
            var aletler = db.aletler.Include(a => a.kategori);
            return View(aletler.ToList());
        }

        // GET: aletlerksayfasi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aletler aletler = db.aletler.Find(id);
            if (aletler == null)
            {
                return HttpNotFound();
            }
            return View(aletler);
        }

        // GET: aletlerksayfasi/Create
        public ActionResult Create()
        {
            ViewBag.kategoriid = new SelectList(db.kategori, "kategorid", "kategoriad");
            return View();
        }

        // POST: aletlerksayfasi/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aletid,kategoriid,aletad,aletaciklama")] aletler aletler)
        {
            if (ModelState.IsValid)
            {
                db.aletler.Add(aletler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kategoriid = new SelectList(db.kategori, "kategorid", "kategoriad", aletler.kategoriid);
            return View(aletler);
        }

        // GET: aletlerksayfasi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aletler aletler = db.aletler.Find(id);
            if (aletler == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategoriid = new SelectList(db.kategori, "kategorid", "kategoriad", aletler.kategoriid);
            return View(aletler);
        }

        // POST: aletlerksayfasi/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aletid,kategoriid,aletad,aletaciklama")] aletler aletler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aletler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kategoriid = new SelectList(db.kategori, "kategorid", "kategoriad", aletler.kategoriid);
            return View(aletler);
        }

        // GET: aletlerksayfasi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aletler aletler = db.aletler.Find(id);
            if (aletler == null)
            {
                return HttpNotFound();
            }
            return View(aletler);
        }

        // POST: aletlerksayfasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aletler aletler = db.aletler.Find(id);
            db.aletler.Remove(aletler);
            db.SaveChanges();
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
