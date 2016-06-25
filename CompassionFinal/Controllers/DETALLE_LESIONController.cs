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
    public class DETALLE_LESIONController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: DETALLE_LESION
        public ActionResult Index()
        {
            var dETALLE_LESION = db.DETALLE_LESION.Include(d => d.INCIDENTE_MEDICO).Include(d => d.LESION);
            return View(dETALLE_LESION.ToList());
        }

        // GET: DETALLE_LESION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_LESION dETALLE_LESION = db.DETALLE_LESION.Find(id);
            if (dETALLE_LESION == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_LESION);
        }

        // GET: DETALLE_LESION/Create
        public ActionResult Create()
        {
            ViewBag.IDincidente = new SelectList(db.INCIDENTE_MEDICO, "IDincidente", "idincidente");
            ViewBag.tipo_lesion = new SelectList(db.LESION, "IDLesion", "nombre");
            return View();
        }

        // POST: DETALLE_LESION/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDdetalleLes,IDincidente,tipo_lesion,cometario")] DETALLE_LESION dETALLE_LESION)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_LESION.Add(dETALLE_LESION);
                db.SaveChanges();
                return RedirectToAction("SearchIndex","INCIDENTE_MEDICO");
            }

            ViewBag.IDincidente = new SelectList(db.INCIDENTE_MEDICO, "IDincidente", "idniño", dETALLE_LESION.IDincidente);
            ViewBag.tipo_lesion = new SelectList(db.LESION, "IDLesion", "nombre", dETALLE_LESION.tipo_lesion);
            return View(dETALLE_LESION);
        }

        // GET: DETALLE_LESION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_LESION dETALLE_LESION = db.DETALLE_LESION.Find(id);
            if (dETALLE_LESION == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDincidente = new SelectList(db.INCIDENTE_MEDICO, "IDincidente", "idniño", dETALLE_LESION.IDincidente);
            ViewBag.tipo_lesion = new SelectList(db.LESION, "IDLesion", "nombre", dETALLE_LESION.tipo_lesion);
            return View(dETALLE_LESION);
        }

        // POST: DETALLE_LESION/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDdetalleLes,IDincidente,tipo_lesion,cometario")] DETALLE_LESION dETALLE_LESION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_LESION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDincidente = new SelectList(db.INCIDENTE_MEDICO, "IDincidente", "idniño", dETALLE_LESION.IDincidente);
            ViewBag.tipo_lesion = new SelectList(db.LESION, "IDLesion", "nombre", dETALLE_LESION.tipo_lesion);
            return View(dETALLE_LESION);
        }

        // GET: DETALLE_LESION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_LESION dETALLE_LESION = db.DETALLE_LESION.Find(id);
            if (dETALLE_LESION == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_LESION);
        }

        // POST: DETALLE_LESION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLE_LESION dETALLE_LESION = db.DETALLE_LESION.Find(id);
            db.DETALLE_LESION.Remove(dETALLE_LESION);
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
