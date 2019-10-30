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
    public class auditoriaController : Controller
    {
        private controlAdministrativoEntities db = new controlAdministrativoEntities();

        // GET: auditoria
        public ActionResult Index()
        {
            var auditoria = db.auditoria.Include(a => a.usuarios).Include(a => a.padres);
            return View(auditoria.ToList());
        }

        // GET: auditoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auditoria auditoria = db.auditoria.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            return View(auditoria);
        }

        // GET: auditoria/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarios = new SelectList(db.usuarios, "id", "cedula");
            ViewBag.idPadres = new SelectList(db.padres, "id", "cedula");
            return View();
        }

        // POST: auditoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,accion,fecha,tabla,modificadoPor,idUsuarios,idPadres")] auditoria auditoria)
        {
            if (ModelState.IsValid)
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarios = new SelectList(db.usuarios, "id", "cedula", auditoria.idUsuarios);
            ViewBag.idPadres = new SelectList(db.padres, "id", "cedula", auditoria.idPadres);
            return View(auditoria);
        }

        // GET: auditoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auditoria auditoria = db.auditoria.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarios = new SelectList(db.usuarios, "id", "cedula", auditoria.idUsuarios);
            ViewBag.idPadres = new SelectList(db.padres, "id", "cedula", auditoria.idPadres);
            return View(auditoria);
        }

        // POST: auditoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,accion,fecha,tabla,modificadoPor,idUsuarios,idPadres")] auditoria auditoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarios = new SelectList(db.usuarios, "id", "cedula", auditoria.idUsuarios);
            ViewBag.idPadres = new SelectList(db.padres, "id", "cedula", auditoria.idPadres);
            return View(auditoria);
        }

        // GET: auditoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auditoria auditoria = db.auditoria.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            return View(auditoria);
        }

        // POST: auditoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            auditoria auditoria = db.auditoria.Find(id);
            db.auditoria.Remove(auditoria);
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
