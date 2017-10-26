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
    public class HorarioGrupoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HorarioGrupoes
        public ActionResult Index()
        {
            return View(db.HorarioGrupoes.ToList());
        }

        // GET: HorarioGrupoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioGrupo horarioGrupo = db.HorarioGrupoes.Find(id);
            if (horarioGrupo == null)
            {
                return HttpNotFound();
            }
            return View(horarioGrupo);
        }

        // GET: HorarioGrupoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HorarioGrupoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CODIGOMATERIA,ANO,PERIODO,GRUPO,DIA,HORA,DURACION,AULA")] HorarioGrupo horarioGrupo)
        {
            if (ModelState.IsValid)
            {
                db.HorarioGrupoes.Add(horarioGrupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horarioGrupo);
        }

        // GET: HorarioGrupoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioGrupo horarioGrupo = db.HorarioGrupoes.Find(id);
            if (horarioGrupo == null)
            {
                return HttpNotFound();
            }
            return View(horarioGrupo);
        }

        // POST: HorarioGrupoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CODIGOMATERIA,ANO,PERIODO,GRUPO,DIA,HORA,DURACION,AULA")] HorarioGrupo horarioGrupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horarioGrupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horarioGrupo);
        }

        // GET: HorarioGrupoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioGrupo horarioGrupo = db.HorarioGrupoes.Find(id);
            if (horarioGrupo == null)
            {
                return HttpNotFound();
            }
            return View(horarioGrupo);
        }

        // POST: HorarioGrupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HorarioGrupo horarioGrupo = db.HorarioGrupoes.Find(id);
            db.HorarioGrupoes.Remove(horarioGrupo);
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
