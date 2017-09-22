using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSoftware2.Models;

namespace ProyectoSoftware2.Controllers
{
    public class PlantillasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Plantillas
        public ActionResult Index()
        {
            return View(db.Plantillas.ToList());
        }

        // GET: Plantillas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plantilla plantilla = db.Plantillas.Find(id);
            if (plantilla == null)
            {
                return HttpNotFound();
            }
            return View(plantilla);
        }

        // GET: Plantillas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plantillas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,descripcion,ruta")] Plantilla plantilla)
        {
            if (ModelState.IsValid)
            {
                db.Plantillas.Add(plantilla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plantilla);
        }

        // GET: Plantillas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plantilla plantilla = db.Plantillas.Find(id);
            if (plantilla == null)
            {
                return HttpNotFound();
            }
            return View(plantilla);
        }

        // POST: Plantillas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,descripcion,ruta")] Plantilla plantilla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantilla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plantilla);
        }

        // GET: Plantillas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plantilla plantilla = db.Plantillas.Find(id);
            if (plantilla == null)
            {
                return HttpNotFound();
            }
            return View(plantilla);
        }

        // POST: Plantillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plantilla plantilla = db.Plantillas.Find(id);
            db.Plantillas.Remove(plantilla);
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
