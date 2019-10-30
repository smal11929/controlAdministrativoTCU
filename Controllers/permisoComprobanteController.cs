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
    public class permisoComprobanteController : Controller
    {
        private controlAdministrativoEntities db = new controlAdministrativoEntities();

        // GET: permisoComprobante
        public ActionResult Index()
        {
            var permisoComprobante = db.permisoComprobante.Include(p => p.boletaPermiso);
            return View(permisoComprobante.ToList());
        }

        // GET: permisoComprobante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permisoComprobante permisoComprobante = db.permisoComprobante.Find(id);
            if (permisoComprobante == null)
            {
                return HttpNotFound();
            }
            return View(permisoComprobante);
        }

        // GET: permisoComprobante/Create
        public ActionResult Create()
        {
            ViewBag.idPermiso = new SelectList(db.boletaPermiso, "id", "departamento");
            return View();
        }

        // POST: permisoComprobante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,presentaComprabante,multaSalario,tipoComprobante,otroComprobante,aprobadoPor,firmadoPor,sello,idPermiso")] permisoComprobante permisoComprobante)
        {
            if (ModelState.IsValid)
            {
                db.permisoComprobante.Add(permisoComprobante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPermiso = new SelectList(db.boletaPermiso, "id", "departamento", permisoComprobante.idPermiso);
            return View(permisoComprobante);
        }

        // GET: permisoComprobante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permisoComprobante permisoComprobante = db.permisoComprobante.Find(id);
            if (permisoComprobante == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPermiso = new SelectList(db.boletaPermiso, "id", "departamento", permisoComprobante.idPermiso);
            return View(permisoComprobante);
        }

        // POST: permisoComprobante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,presentaComprabante,multaSalario,tipoComprobante,otroComprobante,aprobadoPor,firmadoPor,sello,idPermiso")] permisoComprobante permisoComprobante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permisoComprobante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPermiso = new SelectList(db.boletaPermiso, "id", "departamento", permisoComprobante.idPermiso);
            return View(permisoComprobante);
        }

        // GET: permisoComprobante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permisoComprobante permisoComprobante = db.permisoComprobante.Find(id);
            if (permisoComprobante == null)
            {
                return HttpNotFound();
            }
            return View(permisoComprobante);
        }

        // POST: permisoComprobante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            permisoComprobante permisoComprobante = db.permisoComprobante.Find(id);
            db.permisoComprobante.Remove(permisoComprobante);
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
