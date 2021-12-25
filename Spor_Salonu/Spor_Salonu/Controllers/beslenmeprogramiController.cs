﻿using System;
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
    public class beslenmeprogramiController : Controller
    {
        private sporsalonuEntities1 db = new sporsalonuEntities1();

        // GET: beslenmeprogrami
        public ActionResult Index()
        {
            var beslenme = db.beslenme.Include(b => b.gun).Include(b => b.kategori2);
            return View(beslenme.ToList());
        }

        // GET: beslenmeprogrami/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            beslenme beslenme = db.beslenme.Find(id);
            if (beslenme == null)
            {
                return HttpNotFound();
            }
            return View(beslenme);
        }

        // GET: beslenmeprogrami/Create
        public ActionResult Create()
        {
            ViewBag.gunid = new SelectList(db.gun, "gunid", "gunad");
            ViewBag.kategorid = new SelectList(db.kategori2, "kategoriid", "kategoriad");
            return View();
        }

        // POST: beslenmeprogrami/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,kategorid,gunid,aciklamas,aciklamao,aciklamaa")] beslenme beslenme)
        {
            if (ModelState.IsValid)
            {
                db.beslenme.Add(beslenme);
                db.SaveChanges();
                TempData["beslenmeekle"] = " ";
                return RedirectToAction("Index");
            }

            ViewBag.gunid = new SelectList(db.gun, "gunid", "gunad", beslenme.gunid);
            ViewBag.kategorid = new SelectList(db.kategori2, "kategoriid", "kategoriad", beslenme.kategorid);
            return View(beslenme);
        }

        // GET: beslenmeprogrami/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            beslenme beslenme = db.beslenme.Find(id);
            if (beslenme == null)
            {
                return HttpNotFound();
            }
            ViewBag.gunid = new SelectList(db.gun, "gunid", "gunad", beslenme.gunid);
            ViewBag.kategorid = new SelectList(db.kategori2, "kategoriid", "kategoriad", beslenme.kategorid);
            return View(beslenme);
        }

        // POST: beslenmeprogrami/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,kategorid,gunid,aciklamas,aciklamao,aciklamaa")] beslenme beslenme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beslenme).State = EntityState.Modified;
                db.SaveChanges();
                TempData["beslenmeguncelle"] = " ";
                return RedirectToAction("Index");
            }
            ViewBag.gunid = new SelectList(db.gun, "gunid", "gunad", beslenme.gunid);
            ViewBag.kategorid = new SelectList(db.kategori2, "kategoriid", "kategoriad", beslenme.kategorid);
            return View(beslenme);
        }

        // GET: beslenmeprogrami/Delete/5
        public ActionResult Delete(int? id)
        {
            beslenme beslenme = db.beslenme.Find(id);
            db.beslenme.Remove(beslenme);
            db.SaveChanges();
            TempData["beslenmesil"] = " ";
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
