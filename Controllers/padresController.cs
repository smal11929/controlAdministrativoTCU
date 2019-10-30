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
    public class padresController : Controller
    {
        private controlAdministrativoEntities db = new controlAdministrativoEntities();

        // GET: padres
        public ActionResult Index()
        {
            var padres = db.padres.Include(p => p.institucion);
            return View(padres.ToList());
        }

        // GET: padres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            padres padres = db.padres.Find(id);
            if (padres == null)
            {
                return HttpNotFound();
            }
            return View(padres);
        }

        // GET: padres/Create
        public ActionResult Create()
        {
            ViewBag.idInstitucion = new SelectList(db.institucion, "id", "nombre");
            return View();
        }

        // POST: padres/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cedula,nombre,primerApellido,segundoApellido,correo,contraseña,pin,rol,telefono,lugarTrabajo,habilitado,imagen,idInstitucion")] padres padres)
        {
            if (ModelState.IsValid)
            {
                db.padres.Add(padres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idInstitucion = new SelectList(db.institucion, "id", "nombre", padres.idInstitucion);
            return View(padres);
        }

        // GET: padres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            padres padres = db.padres.Find(id);
            if (padres == null)
            {
                return HttpNotFound();
            }
            ViewBag.idInstitucion = new SelectList(db.institucion, "id", "nombre", padres.idInstitucion);
            return View(padres);
        }

        // POST: padres/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cedula,nombre,primerApellido,segundoApellido,correo,contraseña,pin,rol,telefono,lugarTrabajo,habilitado,imagen,idInstitucion")] padres padres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(padres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idInstitucion = new SelectList(db.institucion, "id", "nombre", padres.idInstitucion);
            return View(padres);
        }

        // GET: padres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            padres padres = db.padres.Find(id);
            if (padres == null)
            {
                return HttpNotFound();
            }
            return View(padres);
        }

        // POST: padres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            padres padres = db.padres.Find(id);
            db.padres.Remove(padres);
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
