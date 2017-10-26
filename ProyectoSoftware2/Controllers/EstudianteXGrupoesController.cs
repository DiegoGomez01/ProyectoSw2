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
    public class EstudianteXGrupoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EstudianteXGrupoes
        public ActionResult Index()
        {
            var estudianteXGrupoes = db.EstudianteXGrupoes.Include(e => e.Estudiante).Include(e => e.Group);
            return View(estudianteXGrupoes.ToList());
        }

        // GET: EstudianteXGrupoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstudianteXGrupo estudianteXGrupo = db.EstudianteXGrupoes.Find(id);
            if (estudianteXGrupo == null)
            {
                return HttpNotFound();
            }
            return View(estudianteXGrupo);
        }

        // GET: EstudianteXGrupoes/Create
        public ActionResult Create()
        {
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CODIGO");
            ViewBag.GrupoId = new SelectList(db.Grupoes, "Id", "CODIGOMATERIA");
            return View();
        }

        // POST: EstudianteXGrupoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EstudianteId,GrupoId")] EstudianteXGrupo estudianteXGrupo)
        {
            if (ModelState.IsValid)
            {
                db.EstudianteXGrupoes.Add(estudianteXGrupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CODIGO", estudianteXGrupo.EstudianteId);
            ViewBag.GrupoId = new SelectList(db.Grupoes, "Id", "CODIGOMATERIA", estudianteXGrupo.GrupoId);
            return View(estudianteXGrupo);
        }

        // GET: EstudianteXGrupoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstudianteXGrupo estudianteXGrupo = db.EstudianteXGrupoes.Find(id);
            if (estudianteXGrupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CODIGO", estudianteXGrupo.EstudianteId);
            ViewBag.GrupoId = new SelectList(db.Grupoes, "Id", "CODIGOMATERIA", estudianteXGrupo.GrupoId);
            return View(estudianteXGrupo);
        }

        // POST: EstudianteXGrupoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EstudianteId,GrupoId")] EstudianteXGrupo estudianteXGrupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudianteXGrupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CODIGO", estudianteXGrupo.EstudianteId);
            ViewBag.GrupoId = new SelectList(db.Grupoes, "Id", "CODIGOMATERIA", estudianteXGrupo.GrupoId);
            return View(estudianteXGrupo);
        }

        // GET: EstudianteXGrupoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstudianteXGrupo estudianteXGrupo = db.EstudianteXGrupoes.Find(id);
            if (estudianteXGrupo == null)
            {
                return HttpNotFound();
            }
            return View(estudianteXGrupo);
        }

        // POST: EstudianteXGrupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstudianteXGrupo estudianteXGrupo = db.EstudianteXGrupoes.Find(id);
            db.EstudianteXGrupoes.Remove(estudianteXGrupo);
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
