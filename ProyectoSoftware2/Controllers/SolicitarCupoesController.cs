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
    public class SolicitarCupoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SolicitarCupoes
        public ActionResult Index()
        {
            var solicitarCupoes = db.SolicitarCupoes.Include(s => s.materia);
            return View(solicitarCupoes.ToList());
        }

        // GET: SolicitarCupoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitarCupo solicitarCupo = db.SolicitarCupoes.Find(id);
            if (solicitarCupo == null)
            {
                return HttpNotFound();
            }
            return View(solicitarCupo);
        }

        // GET: SolicitarCupoes/Create
        public ActionResult Create()
        {
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "Nombre");
            return View();
        }

        // POST: SolicitarCupoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MateriaId,CodEstudiante,NombreEstudiante,Fecha")] SolicitarCupo solicitarCupo)
        {
            if (ModelState.IsValid)
            {
                db.SolicitarCupoes.Add(solicitarCupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "Nombre", solicitarCupo.MateriaId);
            return View(solicitarCupo);
        }

        // GET: SolicitarCupoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitarCupo solicitarCupo = db.SolicitarCupoes.Find(id);
            if (solicitarCupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "Nombre", solicitarCupo.MateriaId);
            return View(solicitarCupo);
        }

        // POST: SolicitarCupoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MateriaId,CodEstudiante,NombreEstudiante,Fecha")] SolicitarCupo solicitarCupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitarCupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "Nombre", solicitarCupo.MateriaId);
            return View(solicitarCupo);
        }

        // GET: SolicitarCupoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitarCupo solicitarCupo = db.SolicitarCupoes.Find(id);
            if (solicitarCupo == null)
            {
                return HttpNotFound();
            }
            return View(solicitarCupo);
        }

        // POST: SolicitarCupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitarCupo solicitarCupo = db.SolicitarCupoes.Find(id);
            db.SolicitarCupoes.Remove(solicitarCupo);
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
