using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompassionFinal;

namespace CompassionFinal.Controllers
{
    [Authorize]
    public class DETALLE_HORARIOController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: DETALLE_HORARIO
        public ActionResult Index()
        {
            var dETALLE_HORARIO = db.DETALLE_HORARIO.Include(d => d.GRUPO_CLASE).Include(d => d.DIAS1);
            return View(dETALLE_HORARIO.ToList());
        }

        // GET: DETALLE_HORARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_HORARIO dETALLE_HORARIO = db.DETALLE_HORARIO.Find(id);
            if (dETALLE_HORARIO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_HORARIO);
        }

        // GET: DETALLE_HORARIO/Create
        public ActionResult Create()
        {
            ViewBag.IDgrupo = new SelectList(db.GRUPO_CLASE, "IDgrupo", "descripcion");
            ViewBag.dias = new SelectList(db.DIAS, "IDDIAS", "nombre");
            return View();
        }

        // POST: DETALLE_HORARIO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDetHorario,IDgrupo,dias")] DETALLE_HORARIO dETALLE_HORARIO)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_HORARIO.Add(dETALLE_HORARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDgrupo = new SelectList(db.GRUPO_CLASE, "IDgrupo", "descripcion", dETALLE_HORARIO.IDgrupo);
            ViewBag.dias = new SelectList(db.DIAS, "IDDIAS", "nombre", dETALLE_HORARIO.dias);
            return View(dETALLE_HORARIO);
        }

        // GET: DETALLE_HORARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_HORARIO dETALLE_HORARIO = db.DETALLE_HORARIO.Find(id);
            if (dETALLE_HORARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDgrupo = new SelectList(db.GRUPO_CLASE, "IDgrupo", "descripcion", dETALLE_HORARIO.IDgrupo);
            ViewBag.dias = new SelectList(db.DIAS, "IDDIAS", "nombre", dETALLE_HORARIO.dias);
            return View(dETALLE_HORARIO);
        }

        // POST: DETALLE_HORARIO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDetHorario,IDgrupo,dias")] DETALLE_HORARIO dETALLE_HORARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_HORARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDgrupo = new SelectList(db.GRUPO_CLASE, "IDgrupo", "descripcion", dETALLE_HORARIO.IDgrupo);
            ViewBag.dias = new SelectList(db.DIAS, "IDDIAS", "nombre", dETALLE_HORARIO.dias);
            return View(dETALLE_HORARIO);
        }

        // GET: DETALLE_HORARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_HORARIO dETALLE_HORARIO = db.DETALLE_HORARIO.Find(id);
            if (dETALLE_HORARIO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_HORARIO);
        }

        // POST: DETALLE_HORARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLE_HORARIO dETALLE_HORARIO = db.DETALLE_HORARIO.Find(id);
            db.DETALLE_HORARIO.Remove(dETALLE_HORARIO);
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
