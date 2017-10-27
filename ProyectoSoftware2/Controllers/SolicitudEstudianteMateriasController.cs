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
    public class SolicitudEstudianteMateriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SolicitudEstudianteMaterias
        public ActionResult Index()
        {
            var solicitudEstudianteMaterias = db.SolicitudEstudianteMaterias.Include(s => s.Estudiante).Include(s => s.Materia);
            return View(solicitudEstudianteMaterias.ToList());
        }

        // GET: SolicitudEstudianteMaterias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudEstudianteMateria solicitudEstudianteMateria = db.SolicitudEstudianteMaterias.Find(id);
            if (solicitudEstudianteMateria == null)
            {
                return HttpNotFound();
            }
            return View(solicitudEstudianteMateria);
        }

        // GET: SolicitudEstudianteMaterias/Create
        public ActionResult Create()
        {
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CODIGO");
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NOMBRE");
            return View();
        }

        // POST: SolicitudEstudianteMaterias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EstudianteId,MateriaId")] SolicitudEstudianteMateria solicitudEstudianteMateria)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudEstudianteMaterias.Add(solicitudEstudianteMateria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CODIGO", solicitudEstudianteMateria.EstudianteId);
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NOMBRE", solicitudEstudianteMateria.MateriaId);
            return View(solicitudEstudianteMateria);
        }

        // GET: SolicitudEstudianteMaterias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudEstudianteMateria solicitudEstudianteMateria = db.SolicitudEstudianteMaterias.Find(id);
            if (solicitudEstudianteMateria == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CODIGO", solicitudEstudianteMateria.EstudianteId);
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NOMBRE", solicitudEstudianteMateria.MateriaId);
            return View(solicitudEstudianteMateria);
        }

        // POST: SolicitudEstudianteMaterias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EstudianteId,MateriaId")] SolicitudEstudianteMateria solicitudEstudianteMateria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudEstudianteMateria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CODIGO", solicitudEstudianteMateria.EstudianteId);
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NOMBRE", solicitudEstudianteMateria.MateriaId);
            return View(solicitudEstudianteMateria);
        }

        // GET: SolicitudEstudianteMaterias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudEstudianteMateria solicitudEstudianteMateria = db.SolicitudEstudianteMaterias.Find(id);
            if (solicitudEstudianteMateria == null)
            {
                return HttpNotFound();
            }
            return View(solicitudEstudianteMateria);
        }

        // POST: SolicitudEstudianteMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudEstudianteMateria solicitudEstudianteMateria = db.SolicitudEstudianteMaterias.Find(id);
            db.SolicitudEstudianteMaterias.Remove(solicitudEstudianteMateria);
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
