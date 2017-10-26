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
    public class PreRequisitoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PreRequisitoes
        public ActionResult Index()
        {
            return View(db.PreRequisitoes.ToList());
        }

        // GET: PreRequisitoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreRequisito preRequisito = db.PreRequisitoes.Find(id);
            if (preRequisito == null)
            {
                return HttpNotFound();
            }
            return View(preRequisito);
        }

        // GET: PreRequisitoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PreRequisitoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PENSUM,CODIGOMATERIA,CODIGOMATERIA_PRE")] PreRequisito preRequisito)
        {
            if (ModelState.IsValid)
            {
                db.PreRequisitoes.Add(preRequisito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(preRequisito);
        }

        // GET: PreRequisitoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreRequisito preRequisito = db.PreRequisitoes.Find(id);
            if (preRequisito == null)
            {
                return HttpNotFound();
            }
            return View(preRequisito);
        }

        // POST: PreRequisitoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PENSUM,CODIGOMATERIA,CODIGOMATERIA_PRE")] PreRequisito preRequisito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preRequisito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(preRequisito);
        }

        // GET: PreRequisitoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreRequisito preRequisito = db.PreRequisitoes.Find(id);
            if (preRequisito == null)
            {
                return HttpNotFound();
            }
            return View(preRequisito);
        }

        // POST: PreRequisitoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreRequisito preRequisito = db.PreRequisitoes.Find(id);
            db.PreRequisitoes.Remove(preRequisito);
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
