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
    public class EstudianteXMateriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EstudianteXMaterias
        public ActionResult Index()
        {
            return View(db.EstudianteXMaterias.ToList());
        }

        // GET: EstudianteXMaterias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstudianteXMateria estudianteXMateria = db.EstudianteXMaterias.Find(id);
            if (estudianteXMateria == null)
            {
                return HttpNotFound();
            }
            return View(estudianteXMateria);
        }

        // GET: EstudianteXMaterias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudianteXMaterias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ESTUDIANTEID,MATERIAID,GRUPO,DEFINITIVA,HABILITACION,RECUPERATORIO,FINAL,FALLAS,PERIODO,ANO")] EstudianteXMateria estudianteXMateria)
        {
            if (ModelState.IsValid)
            {
                db.EstudianteXMaterias.Add(estudianteXMateria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudianteXMateria);
        }

        // GET: EstudianteXMaterias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstudianteXMateria estudianteXMateria = db.EstudianteXMaterias.Find(id);
            if (estudianteXMateria == null)
            {
                return HttpNotFound();
            }
            return View(estudianteXMateria);
        }

        // POST: EstudianteXMaterias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ESTUDIANTEID,MATERIAID,GRUPO,DEFINITIVA,HABILITACION,RECUPERATORIO,FINAL,FALLAS,PERIODO,ANO")] EstudianteXMateria estudianteXMateria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudianteXMateria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudianteXMateria);
        }

        // GET: EstudianteXMaterias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstudianteXMateria estudianteXMateria = db.EstudianteXMaterias.Find(id);
            if (estudianteXMateria == null)
            {
                return HttpNotFound();
            }
            return View(estudianteXMateria);
        }

        // POST: EstudianteXMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstudianteXMateria estudianteXMateria = db.EstudianteXMaterias.Find(id);
            db.EstudianteXMaterias.Remove(estudianteXMateria);
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
