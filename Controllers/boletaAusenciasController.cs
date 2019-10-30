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
    public class boletaAusenciasController : Controller
    {
        private controlAdministrativoEntities db = new controlAdministrativoEntities();

        // GET: boletaAusencias
        public ActionResult Index()
        {
            var boletaAusencias = db.boletaAusencias.Include(b => b.ausenciasConsecutivo);
            return View(boletaAusencias.ToList());
        }

        // GET: boletaAusencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boletaAusencias boletaAusencias = db.boletaAusencias.Find(id);
            if (boletaAusencias == null)
            {
                return HttpNotFound();
            }
            return View(boletaAusencias);
        }

        // GET: boletaAusencias/Create
        public ActionResult Create()
        {
            ViewBag.idConsecutivo = new SelectList(db.ausenciasConsecutivo, "id", "id");
            return View();
        }

        // POST: boletaAusencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,nombrePadre,cedulaPadre,nombreEstudiante,seccionEstudiante,justificarAusencias,razonAusencia,firma,recibidoPor,sello,consecutivo,idConsecutivo")] boletaAusencias boletaAusencias)
        {
            if (ModelState.IsValid)
            {
                db.boletaAusencias.Add(boletaAusencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idConsecutivo = new SelectList(db.ausenciasConsecutivo, "id", "id", boletaAusencias.idConsecutivo);
            return View(boletaAusencias);
        }

        // GET: boletaAusencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boletaAusencias boletaAusencias = db.boletaAusencias.Find(id);
            if (boletaAusencias == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConsecutivo = new SelectList(db.ausenciasConsecutivo, "id", "id", boletaAusencias.idConsecutivo);
            return View(boletaAusencias);
        }

        // POST: boletaAusencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,nombrePadre,cedulaPadre,nombreEstudiante,seccionEstudiante,justificarAusencias,razonAusencia,firma,recibidoPor,sello,consecutivo,idConsecutivo")] boletaAusencias boletaAusencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boletaAusencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idConsecutivo = new SelectList(db.ausenciasConsecutivo, "id", "id", boletaAusencias.idConsecutivo);
            return View(boletaAusencias);
        }

        // GET: boletaAusencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boletaAusencias boletaAusencias = db.boletaAusencias.Find(id);
            if (boletaAusencias == null)
            {
                return HttpNotFound();
            }
            return View(boletaAusencias);
        }

        // POST: boletaAusencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            boletaAusencias boletaAusencias = db.boletaAusencias.Find(id);
            db.boletaAusencias.Remove(boletaAusencias);
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
