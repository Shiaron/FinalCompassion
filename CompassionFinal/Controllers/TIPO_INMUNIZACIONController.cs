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
    public class TIPO_INMUNIZACIONController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: TIPO_INMUNIZACION
        public ActionResult Index()
        {
            return View(db.TIPO_INMUNIZACION.ToList());
        }

        // GET: TIPO_INMUNIZACION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_INMUNIZACION tIPO_INMUNIZACION = db.TIPO_INMUNIZACION.Find(id);
            if (tIPO_INMUNIZACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_INMUNIZACION);
        }

        // GET: TIPO_INMUNIZACION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_INMUNIZACION/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDT_Inmunizacion,nombre,nro_dosis,periodo")] TIPO_INMUNIZACION tIPO_INMUNIZACION)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_INMUNIZACION.Add(tIPO_INMUNIZACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_INMUNIZACION);
        }

        // GET: TIPO_INMUNIZACION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_INMUNIZACION tIPO_INMUNIZACION = db.TIPO_INMUNIZACION.Find(id);
            if (tIPO_INMUNIZACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_INMUNIZACION);
        }

        // POST: TIPO_INMUNIZACION/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDT_Inmunizacion,nombre,nro_dosis,periodo")] TIPO_INMUNIZACION tIPO_INMUNIZACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_INMUNIZACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_INMUNIZACION);
        }

        // GET: TIPO_INMUNIZACION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_INMUNIZACION tIPO_INMUNIZACION = db.TIPO_INMUNIZACION.Find(id);
            if (tIPO_INMUNIZACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_INMUNIZACION);
        }

        // POST: TIPO_INMUNIZACION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_INMUNIZACION tIPO_INMUNIZACION = db.TIPO_INMUNIZACION.Find(id);
            db.TIPO_INMUNIZACION.Remove(tIPO_INMUNIZACION);
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
