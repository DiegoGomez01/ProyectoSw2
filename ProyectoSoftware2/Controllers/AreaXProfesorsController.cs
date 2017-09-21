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
    public class AreaXProfesorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AreaXProfesors
        public ActionResult Index()
        {
            var areaXProfesors = db.AreaXProfesors.Include(a => a.Area).Include(a => a.Profesor);
            return View(areaXProfesors.ToList());
        }

        // GET: AreaXProfesors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaXProfesor areaXProfesor = db.AreaXProfesors.Find(id);
            if (areaXProfesor == null)
            {
                return HttpNotFound();
            }
            return View(areaXProfesor);
        }

        // GET: AreaXProfesors/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre");
            ViewBag.ProfesorId = new SelectList(db.Profesors, "Id", "Nombre");
            return View();
        }

        // POST: AreaXProfesors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProfesorId,AreaId")] AreaXProfesor areaXProfesor)
        {
            if (ModelState.IsValid)
            {
                db.AreaXProfesors.Add(areaXProfesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre", areaXProfesor.AreaId);
            ViewBag.ProfesorId = new SelectList(db.Profesors, "Id", "Nombre", areaXProfesor.ProfesorId);
            return View(areaXProfesor);
        }

        // GET: AreaXProfesors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaXProfesor areaXProfesor = db.AreaXProfesors.Find(id);
            if (areaXProfesor == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre", areaXProfesor.AreaId);
            ViewBag.ProfesorId = new SelectList(db.Profesors, "Id", "Nombre", areaXProfesor.ProfesorId);
            return View(areaXProfesor);
        }

        // POST: AreaXProfesors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProfesorId,AreaId")] AreaXProfesor areaXProfesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areaXProfesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre", areaXProfesor.AreaId);
            ViewBag.ProfesorId = new SelectList(db.Profesors, "Id", "Nombre", areaXProfesor.ProfesorId);
            return View(areaXProfesor);
        }

        // GET: AreaXProfesors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaXProfesor areaXProfesor = db.AreaXProfesors.Find(id);
            if (areaXProfesor == null)
            {
                return HttpNotFound();
            }
            return View(areaXProfesor);
        }

        // POST: AreaXProfesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreaXProfesor areaXProfesor = db.AreaXProfesors.Find(id);
            db.AreaXProfesors.Remove(areaXProfesor);
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
