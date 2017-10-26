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
    public class MateriaXPrerequisitoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MateriaXPrerequisitoes
        public ActionResult Index()
        {
            var materiaXPrerequisitoes = db.MateriaXPrerequisitoes.Include(m => m.Materia).Include(m => m.PreRequisito);
            return View(materiaXPrerequisitoes.ToList());
        }

        // GET: MateriaXPrerequisitoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaXPrerequisito materiaXPrerequisito = db.MateriaXPrerequisitoes.Find(id);
            if (materiaXPrerequisito == null)
            {
                return HttpNotFound();
            }
            return View(materiaXPrerequisito);
        }

        // GET: MateriaXPrerequisitoes/Create
        public ActionResult Create()
        {
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NOMBRE");
            ViewBag.PreRequisitoId = new SelectList(db.PreRequisitoes, "Id", "PENSUM");
            return View();
        }

        // POST: MateriaXPrerequisitoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MateriaId,PreRequisitoId")] MateriaXPrerequisito materiaXPrerequisito)
        {
            if (ModelState.IsValid)
            {
                db.MateriaXPrerequisitoes.Add(materiaXPrerequisito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NOMBRE", materiaXPrerequisito.MateriaId);
            ViewBag.PreRequisitoId = new SelectList(db.PreRequisitoes, "Id", "PENSUM", materiaXPrerequisito.PreRequisitoId);
            return View(materiaXPrerequisito);
        }

        // GET: MateriaXPrerequisitoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaXPrerequisito materiaXPrerequisito = db.MateriaXPrerequisitoes.Find(id);
            if (materiaXPrerequisito == null)
            {
                return HttpNotFound();
            }
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NOMBRE", materiaXPrerequisito.MateriaId);
            ViewBag.PreRequisitoId = new SelectList(db.PreRequisitoes, "Id", "PENSUM", materiaXPrerequisito.PreRequisitoId);
            return View(materiaXPrerequisito);
        }

        // POST: MateriaXPrerequisitoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MateriaId,PreRequisitoId")] MateriaXPrerequisito materiaXPrerequisito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materiaXPrerequisito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NOMBRE", materiaXPrerequisito.MateriaId);
            ViewBag.PreRequisitoId = new SelectList(db.PreRequisitoes, "Id", "PENSUM", materiaXPrerequisito.PreRequisitoId);
            return View(materiaXPrerequisito);
        }

        // GET: MateriaXPrerequisitoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaXPrerequisito materiaXPrerequisito = db.MateriaXPrerequisitoes.Find(id);
            if (materiaXPrerequisito == null)
            {
                return HttpNotFound();
            }
            return View(materiaXPrerequisito);
        }

        // POST: MateriaXPrerequisitoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MateriaXPrerequisito materiaXPrerequisito = db.MateriaXPrerequisitoes.Find(id);
            db.MateriaXPrerequisitoes.Remove(materiaXPrerequisito);
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
