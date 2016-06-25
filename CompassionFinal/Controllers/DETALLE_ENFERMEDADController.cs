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
    public class DETALLE_ENFERMEDADController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: DETALLE_ENFERMEDAD
        public ActionResult Index()
        {
            var dETALLE_ENFERMEDAD = db.DETALLE_ENFERMEDAD.Include(d => d.CATEGORIA_ENFERMEDAD).Include(d => d.INCIDENTE_MEDICO).Include(d => d.SUBCATEGORIA_ENFERMEDAD);
            return View(dETALLE_ENFERMEDAD.ToList());
        }

        // GET: DETALLE_ENFERMEDAD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_ENFERMEDAD dETALLE_ENFERMEDAD = db.DETALLE_ENFERMEDAD.Find(id);
            if (dETALLE_ENFERMEDAD == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_ENFERMEDAD);
        }

        // GET: DETALLE_ENFERMEDAD/Create
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(db.CATEGORIA_ENFERMEDAD, "IDCategEnf", "nombre");
            ViewBag.idincidente = new SelectList(db.INCIDENTE_MEDICO, "IDincidente", "idincidente");
            ViewBag.subcategoria = new SelectList(db.SUBCATEGORIA_ENFERMEDAD, "IDSubEnf", "nombre");
            return View();
        }

        // POST: DETALLE_ENFERMEDAD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDdetalleEnf,idincidente,categoria,subcategoria,descripcion")] DETALLE_ENFERMEDAD dETALLE_ENFERMEDAD)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_ENFERMEDAD.Add(dETALLE_ENFERMEDAD);
                db.SaveChanges();
                return RedirectToAction("SearchIndex", "INCIDENTE_MEDICO");
            }

            ViewBag.categoria = new SelectList(db.CATEGORIA_ENFERMEDAD, "IDCategEnf", "nombre", dETALLE_ENFERMEDAD.categoria);
            ViewBag.idincidente = new SelectList(db.INCIDENTE_MEDICO, "IDincidente", "idniño", dETALLE_ENFERMEDAD.idincidente);
            ViewBag.subcategoria = new SelectList(db.SUBCATEGORIA_ENFERMEDAD, "IDSubEnf", "nombre", dETALLE_ENFERMEDAD.subcategoria);
            return View(dETALLE_ENFERMEDAD);
        }

        // GET: DETALLE_ENFERMEDAD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_ENFERMEDAD dETALLE_ENFERMEDAD = db.DETALLE_ENFERMEDAD.Find(id);
            if (dETALLE_ENFERMEDAD == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria = new SelectList(db.CATEGORIA_ENFERMEDAD, "IDCategEnf", "nombre", dETALLE_ENFERMEDAD.categoria);
            ViewBag.idincidente = new SelectList(db.INCIDENTE_MEDICO, "IDincidente", "idniño", dETALLE_ENFERMEDAD.idincidente);
            ViewBag.subcategoria = new SelectList(db.SUBCATEGORIA_ENFERMEDAD, "IDSubEnf", "nombre", dETALLE_ENFERMEDAD.subcategoria);
            return View(dETALLE_ENFERMEDAD);
        }

        // POST: DETALLE_ENFERMEDAD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDdetalleEnf,idincidente,categoria,subcategoria,descripcion")] DETALLE_ENFERMEDAD dETALLE_ENFERMEDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_ENFERMEDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.CATEGORIA_ENFERMEDAD, "IDCategEnf", "nombre", dETALLE_ENFERMEDAD.categoria);
            ViewBag.idincidente = new SelectList(db.INCIDENTE_MEDICO, "IDincidente", "idniño", dETALLE_ENFERMEDAD.idincidente);
            ViewBag.subcategoria = new SelectList(db.SUBCATEGORIA_ENFERMEDAD, "IDSubEnf", "nombre", dETALLE_ENFERMEDAD.subcategoria);
            return View(dETALLE_ENFERMEDAD);
        }

        // GET: DETALLE_ENFERMEDAD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_ENFERMEDAD dETALLE_ENFERMEDAD = db.DETALLE_ENFERMEDAD.Find(id);
            if (dETALLE_ENFERMEDAD == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_ENFERMEDAD);
        }

        // POST: DETALLE_ENFERMEDAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLE_ENFERMEDAD dETALLE_ENFERMEDAD = db.DETALLE_ENFERMEDAD.Find(id);
            db.DETALLE_ENFERMEDAD.Remove(dETALLE_ENFERMEDAD);
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
