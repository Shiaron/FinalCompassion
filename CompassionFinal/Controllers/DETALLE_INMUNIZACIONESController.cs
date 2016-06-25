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
    public class DETALLE_INMUNIZACIONESController : Controller
    {
        private Entities1 db = new Entities1();
        private DETALLE_INMUNIZACIONES detalle = new DETALLE_INMUNIZACIONES();
        
        // GET: DETALLE_INMUNIZACIONES
        public ActionResult Index()
        {
            var dETALLE_INMUNIZACIONES = db.DETALLE_INMUNIZACIONES.Include(d => d.DOSIS1).Include(d => d.Niño).Include(d => d.TIPO_INMUNIZACION1);
            return View(dETALLE_INMUNIZACIONES.ToList());
        }

        // GET: DETALLE_INMUNIZACIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_INMUNIZACIONES dETALLE_INMUNIZACIONES = db.DETALLE_INMUNIZACIONES.Find(id);
            if (dETALLE_INMUNIZACIONES == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_INMUNIZACIONES);
        }

        // GET: DETALLE_INMUNIZACIONES/Create
        public ActionResult Create()
        {
            ViewBag.dosis = new SelectList(db.DOSIS, "IDDosis", "nombre");
            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres");
            ViewBag.tipo_inmunizacion = new SelectList(db.TIPO_INMUNIZACION, "IDT_Inmunizacion", "nombre");
            return View();
        }

        // POST: DETALLE_INMUNIZACIONES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDInmunizacion,idniño,fecha,tipo_inmunizacion,dosis")] DETALLE_INMUNIZACIONES dETALLE_INMUNIZACIONES)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_INMUNIZACIONES.Add(dETALLE_INMUNIZACIONES);
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }

            ViewBag.dosis = new SelectList(db.DOSIS, "IDDosis", "nombre", dETALLE_INMUNIZACIONES.dosis);
            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres", dETALLE_INMUNIZACIONES.idniño);
            ViewBag.tipo_inmunizacion = new SelectList(db.TIPO_INMUNIZACION, "IDT_Inmunizacion", "nombre", dETALLE_INMUNIZACIONES.tipo_inmunizacion);
            return View(dETALLE_INMUNIZACIONES);
        }

        // GET: DETALLE_INMUNIZACIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_INMUNIZACIONES dETALLE_INMUNIZACIONES = db.DETALLE_INMUNIZACIONES.Find(id);
            if (dETALLE_INMUNIZACIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.dosis = new SelectList(db.DOSIS, "IDDosis", "nombre", dETALLE_INMUNIZACIONES.dosis);
            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres", dETALLE_INMUNIZACIONES.idniño);
            ViewBag.tipo_inmunizacion = new SelectList(db.TIPO_INMUNIZACION, "IDT_Inmunizacion", "nombre", dETALLE_INMUNIZACIONES.tipo_inmunizacion);
            return View(dETALLE_INMUNIZACIONES);
        }

        // POST: DETALLE_INMUNIZACIONES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDInmunizacion,idniño,fecha,tipo_inmunizacion,dosis,estado")] DETALLE_INMUNIZACIONES dETALLE_INMUNIZACIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_INMUNIZACIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }
            ViewBag.dosis = new SelectList(db.DOSIS, "IDDosis", "nombre", dETALLE_INMUNIZACIONES.dosis);
            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres", dETALLE_INMUNIZACIONES.idniño);
            ViewBag.tipo_inmunizacion = new SelectList(db.TIPO_INMUNIZACION, "IDT_Inmunizacion", "nombre", dETALLE_INMUNIZACIONES.tipo_inmunizacion);
            return View(dETALLE_INMUNIZACIONES);
        }

        // GET: DETALLE_INMUNIZACIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_INMUNIZACIONES dETALLE_INMUNIZACIONES = db.DETALLE_INMUNIZACIONES.Find(id);
            if (dETALLE_INMUNIZACIONES == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_INMUNIZACIONES);
        }

        // POST: DETALLE_INMUNIZACIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLE_INMUNIZACIONES dETALLE_INMUNIZACIONES = db.DETALLE_INMUNIZACIONES.Find(id);
            db.DETALLE_INMUNIZACIONES.Remove(dETALLE_INMUNIZACIONES);
            db.SaveChanges();
            return RedirectToAction("SearchIndex");
        }

        public ActionResult SearchIndex(string searchString)
        {

            var detalles = from m in db.DETALLE_INMUNIZACIONES
                        select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                detalles = detalles.Where(s => s.idniño.Contains(searchString));
                
            }
            return View(detalles);
        }

        [HttpPost]
        public string SearchIndex(FormCollection fc, string searchString)
        {
            return "<h3> From [HttpPost]SearchIndex: " + searchString + "</h3>";
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
