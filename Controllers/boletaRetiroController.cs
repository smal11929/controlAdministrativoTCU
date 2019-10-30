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
    public class boletaRetiroController : Controller
    {
        private controlAdministrativoEntities db = new controlAdministrativoEntities();

        // GET: boletaRetiro
        public ActionResult Index()
        {
            var boletaRetiro = db.boletaRetiro.Include(b => b.retiroConsecutivo);
            return View(boletaRetiro.ToList());
        }

        // GET: boletaRetiro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boletaRetiro boletaRetiro = db.boletaRetiro.Find(id);
            if (boletaRetiro == null)
            {
                return HttpNotFound();
            }
            return View(boletaRetiro);
        }

        // GET: boletaRetiro/Create
        public ActionResult Create()
        {
            ViewBag.idConsecutivo = new SelectList(db.retiroConsecutivo, "id", "id");
            return View();
        }

        // POST: boletaRetiro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,nombrePadre,cedulaPadre,nombreEstudiante,seccionEstudiante,retiroLecciones,justificarRetiro,firma,recibidoPor,sello,consecutivo,idConsecutivo")] boletaRetiro boletaRetiro)
        {
            if (ModelState.IsValid)
            {
                db.boletaRetiro.Add(boletaRetiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idConsecutivo = new SelectList(db.retiroConsecutivo, "id", "id", boletaRetiro.idConsecutivo);
            return View(boletaRetiro);
        }

        // GET: boletaRetiro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boletaRetiro boletaRetiro = db.boletaRetiro.Find(id);
            if (boletaRetiro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConsecutivo = new SelectList(db.retiroConsecutivo, "id", "id", boletaRetiro.idConsecutivo);
            return View(boletaRetiro);
        }

        // POST: boletaRetiro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,nombrePadre,cedulaPadre,nombreEstudiante,seccionEstudiante,retiroLecciones,justificarRetiro,firma,recibidoPor,sello,consecutivo,idConsecutivo")] boletaRetiro boletaRetiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boletaRetiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idConsecutivo = new SelectList(db.retiroConsecutivo, "id", "id", boletaRetiro.idConsecutivo);
            return View(boletaRetiro);
        }

        // GET: boletaRetiro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boletaRetiro boletaRetiro = db.boletaRetiro.Find(id);
            if (boletaRetiro == null)
            {
                return HttpNotFound();
            }
            return View(boletaRetiro);
        }

        // POST: boletaRetiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            boletaRetiro boletaRetiro = db.boletaRetiro.Find(id);
            db.boletaRetiro.Remove(boletaRetiro);
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
