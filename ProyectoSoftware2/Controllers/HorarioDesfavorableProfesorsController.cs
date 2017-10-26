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
    public class HorarioDesfavorableProfesorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HorarioDesfavorableProfesors
        public ActionResult Index()
        {
            return View(db.HorarioDesfavorableProfesors.ToList());
        }

        // GET: HorarioDesfavorableProfesors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioDesfavorableProfesor horarioDesfavorableProfesor = db.HorarioDesfavorableProfesors.Find(id);
            if (horarioDesfavorableProfesor == null)
            {
                return HttpNotFound();
            }
            return View(horarioDesfavorableProfesor);
        }

        // GET: HorarioDesfavorableProfesors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HorarioDesfavorableProfesors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CEDULADOCENTE,DIA,HORA,DURACION")] HorarioDesfavorableProfesor horarioDesfavorableProfesor)
        {
            if (ModelState.IsValid)
            {
                db.HorarioDesfavorableProfesors.Add(horarioDesfavorableProfesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horarioDesfavorableProfesor);
        }

        // GET: HorarioDesfavorableProfesors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioDesfavorableProfesor horarioDesfavorableProfesor = db.HorarioDesfavorableProfesors.Find(id);
            if (horarioDesfavorableProfesor == null)
            {
                return HttpNotFound();
            }
            return View(horarioDesfavorableProfesor);
        }

        // POST: HorarioDesfavorableProfesors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CEDULADOCENTE,DIA,HORA,DURACION")] HorarioDesfavorableProfesor horarioDesfavorableProfesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horarioDesfavorableProfesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horarioDesfavorableProfesor);
        }

        // GET: HorarioDesfavorableProfesors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioDesfavorableProfesor horarioDesfavorableProfesor = db.HorarioDesfavorableProfesors.Find(id);
            if (horarioDesfavorableProfesor == null)
            {
                return HttpNotFound();
            }
            return View(horarioDesfavorableProfesor);
        }

        // POST: HorarioDesfavorableProfesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HorarioDesfavorableProfesor horarioDesfavorableProfesor = db.HorarioDesfavorableProfesors.Find(id);
            db.HorarioDesfavorableProfesors.Remove(horarioDesfavorableProfesor);
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
