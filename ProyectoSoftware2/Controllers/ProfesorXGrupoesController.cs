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
    public class ProfesorXGrupoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProfesorXGrupoes
        public ActionResult Index()
        {
            var profesorXGrupoes = db.ProfesorXGrupoes.Include(p => p.Grupo).Include(p => p.Profesor);
            return View(profesorXGrupoes.ToList());
        }

        // GET: ProfesorXGrupoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorXGrupo profesorXGrupo = db.ProfesorXGrupoes.Find(id);
            if (profesorXGrupo == null)
            {
                return HttpNotFound();
            }
            return View(profesorXGrupo);
        }

        // GET: ProfesorXGrupoes/Create
        public ActionResult Create()
        {
            ViewBag.GrupoId = new SelectList(db.Grupoes, "Id", "CODIGOMATERIA");
            ViewBag.ProfesorId = new SelectList(db.Profesors, "Id", "P_APELLIDO");
            return View();
        }

        // POST: ProfesorXGrupoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProfesorId,GrupoId,HorasDictadas")] ProfesorXGrupo profesorXGrupo)
        {
            if (ModelState.IsValid)
            {
                db.ProfesorXGrupoes.Add(profesorXGrupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrupoId = new SelectList(db.Grupoes, "Id", "CODIGOMATERIA", profesorXGrupo.GrupoId);
            ViewBag.ProfesorId = new SelectList(db.Profesors, "Id", "P_APELLIDO", profesorXGrupo.ProfesorId);
            return View(profesorXGrupo);
        }

        // GET: ProfesorXGrupoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorXGrupo profesorXGrupo = db.ProfesorXGrupoes.Find(id);
            if (profesorXGrupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupoId = new SelectList(db.Grupoes, "Id", "CODIGOMATERIA", profesorXGrupo.GrupoId);
            ViewBag.ProfesorId = new SelectList(db.Profesors, "Id", "P_APELLIDO", profesorXGrupo.ProfesorId);
            return View(profesorXGrupo);
        }

        // POST: ProfesorXGrupoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProfesorId,GrupoId,HorasDictadas")] ProfesorXGrupo profesorXGrupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesorXGrupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupoId = new SelectList(db.Grupoes, "Id", "CODIGOMATERIA", profesorXGrupo.GrupoId);
            ViewBag.ProfesorId = new SelectList(db.Profesors, "Id", "P_APELLIDO", profesorXGrupo.ProfesorId);
            return View(profesorXGrupo);
        }

        // GET: ProfesorXGrupoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorXGrupo profesorXGrupo = db.ProfesorXGrupoes.Find(id);
            if (profesorXGrupo == null)
            {
                return HttpNotFound();
            }
            return View(profesorXGrupo);
        }

        // POST: ProfesorXGrupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfesorXGrupo profesorXGrupo = db.ProfesorXGrupoes.Find(id);
            db.ProfesorXGrupoes.Remove(profesorXGrupo);
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
