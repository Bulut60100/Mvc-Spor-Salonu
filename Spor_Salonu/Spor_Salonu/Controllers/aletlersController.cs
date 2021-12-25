using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Spor_Salonu.Models;
using Spor_Salonu.App_Code;
using System.IO;

namespace Spor_Salonu.Controllers
{
    public class aletlersController : Controller
    {
        private sporsalonuEntities1 db = new sporsalonuEntities1();

        // GET: aletlers
        public ActionResult Index()
        {
            var aletler = db.aletler.Include(a => a.kategori);
            return View(aletler.ToList());
        }

        // GET: aletlers/Details/5
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

        // GET: aletlers/Create
        public ActionResult Create()
        {
            ViewBag.kategoriid = new SelectList(db.kategori, "kategorid", "kategoriad");
            return View();
        }

        // POST: aletlers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aletid,kategoriid,aletad,aletaciklama,foto")] aletler aletler,HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                if(foto.ContentLength > 0)
                {
                    var image = Path.GetFileName(foto.FileName);
                    var path = Path.Combine(Server.MapPath("~/web/assets/img"), image);
                    foto.SaveAs(path);
                    aletler.foto = "/web/assets/img/"+image;
                    db.aletler.Add(aletler);
                    db.SaveChanges();
                    TempData["aletekle"] = " ";
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }

            ViewBag.kategoriid = new SelectList(db.kategori, "kategorid", "kategoriad", aletler.kategoriid);
            return View(aletler);
        }

        // GET: aletlers/Edit/5
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

        // POST: aletlers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aletid,kategoriid,aletad,aletaciklama,foto")] aletler aletler,HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                if (foto.ContentLength > 0)
                {
                    var image = Path.GetFileName(foto.FileName);
                    var path = Path.Combine(Server.MapPath("~/web/assets/img"), image);
                    foto.SaveAs(path);
                    aletler.foto = "/web/assets/img/" + image;
                    db.Entry(aletler).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["aletguncelle"] = " ";
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }
            ViewBag.kategoriid = new SelectList(db.kategori, "kategorid", "kategoriad", aletler.kategoriid);
            return View(aletler);
        }

        // GET: aletlers/Delete/5
        public ActionResult Delete(int? id)
        {
            aletler aletler = db.aletler.Find(id);
            db.aletler.Remove(aletler);
            db.SaveChanges();
            TempData["aletsil"] = " ";
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
