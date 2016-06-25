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
    public class GRADO_INSTRUCCIONController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: GRADO_INSTRUCCION
        public ActionResult Index()
        {
            return View(db.GRADO_INSTRUCCION.ToList());
        }

        // GET: GRADO_INSTRUCCION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRADO_INSTRUCCION gRADO_INSTRUCCION = db.GRADO_INSTRUCCION.Find(id);
            if (gRADO_INSTRUCCION == null)
            {
                return HttpNotFound();
            }
            return View(gRADO_INSTRUCCION);
        }

        // GET: GRADO_INSTRUCCION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GRADO_INSTRUCCION/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDgrado,nombres")] GRADO_INSTRUCCION gRADO_INSTRUCCION)
        {
            if (ModelState.IsValid)
            {
                db.GRADO_INSTRUCCION.Add(gRADO_INSTRUCCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gRADO_INSTRUCCION);
        }

        // GET: GRADO_INSTRUCCION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRADO_INSTRUCCION gRADO_INSTRUCCION = db.GRADO_INSTRUCCION.Find(id);
            if (gRADO_INSTRUCCION == null)
            {
                return HttpNotFound();
            }
            return View(gRADO_INSTRUCCION);
        }

        // POST: GRADO_INSTRUCCION/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDgrado,nombres")] GRADO_INSTRUCCION gRADO_INSTRUCCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gRADO_INSTRUCCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gRADO_INSTRUCCION);
        }

        // GET: GRADO_INSTRUCCION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRADO_INSTRUCCION gRADO_INSTRUCCION = db.GRADO_INSTRUCCION.Find(id);
            if (gRADO_INSTRUCCION == null)
            {
                return HttpNotFound();
            }
            return View(gRADO_INSTRUCCION);
        }

        // POST: GRADO_INSTRUCCION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GRADO_INSTRUCCION gRADO_INSTRUCCION = db.GRADO_INSTRUCCION.Find(id);
            db.GRADO_INSTRUCCION.Remove(gRADO_INSTRUCCION);
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
