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
    public class institucionController : Controller
    {
        private controlAdministrativoEntities db = new controlAdministrativoEntities();

        // GET: institucion
        public ActionResult Index()
        {
            var institucion = db.institucion.Include(i => i.codigoActivacion).Include(i => i.terminosCondiciones);
            return View(institucion.ToList());
        }

        // GET: institucion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            institucion institucion = db.institucion.Find(id);
            if (institucion == null)
            {
                return HttpNotFound();
            }
            return View(institucion);
        }

        // GET: institucion/Create
        public ActionResult Create()
        {
            ViewBag.idCA = new SelectList(db.codigoActivacion, "id", "codigo");
            ViewBag.idTC = new SelectList(db.terminosCondiciones, "id", "id");
            return View();
        }

        // POST: institucion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,correo,direccion,provincia,canton,distrito,telefono,notas,cedula,logo,sello,idTC,idCA")] institucion institucion)
        {
            if (ModelState.IsValid)
            {
                db.institucion.Add(institucion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCA = new SelectList(db.codigoActivacion, "id", "codigo", institucion.idCA);
            ViewBag.idTC = new SelectList(db.terminosCondiciones, "id", "id", institucion.idTC);
            return View(institucion);
        }

        // GET: institucion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            institucion institucion = db.institucion.Find(id);
            if (institucion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCA = new SelectList(db.codigoActivacion, "id", "codigo", institucion.idCA);
            ViewBag.idTC = new SelectList(db.terminosCondiciones, "id", "id", institucion.idTC);
            return View(institucion);
        }

        // POST: institucion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,correo,direccion,provincia,canton,distrito,telefono,notas,cedula,logo,sello,idTC,idCA")] institucion institucion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institucion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCA = new SelectList(db.codigoActivacion, "id", "codigo", institucion.idCA);
            ViewBag.idTC = new SelectList(db.terminosCondiciones, "id", "id", institucion.idTC);
            return View(institucion);
        }

        // GET: institucion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            institucion institucion = db.institucion.Find(id);
            if (institucion == null)
            {
                return HttpNotFound();
            }
            return View(institucion);
        }

        // POST: institucion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            institucion institucion = db.institucion.Find(id);
            db.institucion.Remove(institucion);
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
