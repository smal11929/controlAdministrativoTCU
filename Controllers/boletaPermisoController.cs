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
    public class boletaPermisoController : Controller
    {
        private controlAdministrativoEntities db = new controlAdministrativoEntities();

        // GET: boletaPermiso
        public ActionResult Index()
        {
            var boletaPermiso = db.boletaPermiso.Include(b => b.permisoConsecutivo);
            return View(boletaPermiso.ToList());
        }

        // GET: boletaPermiso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boletaPermiso boletaPermiso = db.boletaPermiso.Find(id);
            if (boletaPermiso == null)
            {
                return HttpNotFound();
            }
            return View(boletaPermiso);
        }

        // GET: boletaPermiso/Create
        public ActionResult Create()
        {
            ViewBag.idConsecutivo = new SelectList(db.permisoConsecutivo, "id", "id");
            return View();
        }

        // POST: boletaPermiso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,departamento,nombreFuncionario,cedulaFuncionario,permisoAusencia,najoHorario,permisoRetiro,justificarAusencia,justificarLlegadaTardia,adjunto,estado,sello,aprobadoPor,firmadoPor,consecutivo,idConsecutivo")] boletaPermiso boletaPermiso)
        {
            if (ModelState.IsValid)
            {
                db.boletaPermiso.Add(boletaPermiso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idConsecutivo = new SelectList(db.permisoConsecutivo, "id", "id", boletaPermiso.idConsecutivo);
            return View(boletaPermiso);
        }

        // GET: boletaPermiso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boletaPermiso boletaPermiso = db.boletaPermiso.Find(id);
            if (boletaPermiso == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConsecutivo = new SelectList(db.permisoConsecutivo, "id", "id", boletaPermiso.idConsecutivo);
            return View(boletaPermiso);
        }

        // POST: boletaPermiso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,departamento,nombreFuncionario,cedulaFuncionario,permisoAusencia,najoHorario,permisoRetiro,justificarAusencia,justificarLlegadaTardia,adjunto,estado,sello,aprobadoPor,firmadoPor,consecutivo,idConsecutivo")] boletaPermiso boletaPermiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boletaPermiso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idConsecutivo = new SelectList(db.permisoConsecutivo, "id", "id", boletaPermiso.idConsecutivo);
            return View(boletaPermiso);
        }

        // GET: boletaPermiso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boletaPermiso boletaPermiso = db.boletaPermiso.Find(id);
            if (boletaPermiso == null)
            {
                return HttpNotFound();
            }
            return View(boletaPermiso);
        }

        // POST: boletaPermiso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            boletaPermiso boletaPermiso = db.boletaPermiso.Find(id);
            db.boletaPermiso.Remove(boletaPermiso);
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
