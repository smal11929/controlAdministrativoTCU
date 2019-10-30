using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using controlAdministrativo.Models;

namespace controlAdministrativo.Controllers
{
    public class historialController : Controller
    {
        private controlAdministrativoEntities db = new controlAdministrativoEntities();

        // GET: historial
        public ActionResult Index()
        {
            var historial = db.historial.Include(h => h.usuarios).Include(h => h.padres);
            return View(historial.ToList());
        }

        // GET: historial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historial historial = db.historial.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // GET: historial/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarios = new SelectList(db.usuarios, "id", "cedula");
            ViewBag.idPadres = new SelectList(db.padres, "id", "cedula");
            return View();
        }

        // POST: historial/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,accion,fecha,idUsuarios,idPadres")] historial historial)
        {
            if (ModelState.IsValid)
            {
                db.historial.Add(historial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarios = new SelectList(db.usuarios, "id", "cedula", historial.idUsuarios);
            ViewBag.idPadres = new SelectList(db.padres, "id", "cedula", historial.idPadres);
            return View(historial);
        }

        // GET: historial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historial historial = db.historial.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarios = new SelectList(db.usuarios, "id", "cedula", historial.idUsuarios);
            ViewBag.idPadres = new SelectList(db.padres, "id", "cedula", historial.idPadres);
            return View(historial);
        }

        // POST: historial/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,accion,fecha,idUsuarios,idPadres")] historial historial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarios = new SelectList(db.usuarios, "id", "cedula", historial.idUsuarios);
            ViewBag.idPadres = new SelectList(db.padres, "id", "cedula", historial.idPadres);
            return View(historial);
        }

        // GET: historial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historial historial = db.historial.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // POST: historial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            historial historial = db.historial.Find(id);
            db.historial.Remove(historial);
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
