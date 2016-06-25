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
    public class SUBCATEGORIA_ENFERMEDADController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: SUBCATEGORIA_ENFERMEDAD
        public ActionResult Index()
        {
            var sUBCATEGORIA_ENFERMEDAD = db.SUBCATEGORIA_ENFERMEDAD.Include(s => s.CATEGORIA_ENFERMEDAD);
            return View(sUBCATEGORIA_ENFERMEDAD.ToList());
        }

        // GET: SUBCATEGORIA_ENFERMEDAD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORIA_ENFERMEDAD sUBCATEGORIA_ENFERMEDAD = db.SUBCATEGORIA_ENFERMEDAD.Find(id);
            if (sUBCATEGORIA_ENFERMEDAD == null)
            {
                return HttpNotFound();
            }
            return View(sUBCATEGORIA_ENFERMEDAD);
        }

        // GET: SUBCATEGORIA_ENFERMEDAD/Create
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(db.CATEGORIA_ENFERMEDAD, "IDCategEnf", "nombre");
            return View();
        }

        // POST: SUBCATEGORIA_ENFERMEDAD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSubEnf,nombre,categoria")] SUBCATEGORIA_ENFERMEDAD sUBCATEGORIA_ENFERMEDAD)
        {
            if (ModelState.IsValid)
            {
                db.SUBCATEGORIA_ENFERMEDAD.Add(sUBCATEGORIA_ENFERMEDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(db.CATEGORIA_ENFERMEDAD, "IDCategEnf", "nombre", sUBCATEGORIA_ENFERMEDAD.categoria);
            return View(sUBCATEGORIA_ENFERMEDAD);
        }

        // GET: SUBCATEGORIA_ENFERMEDAD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORIA_ENFERMEDAD sUBCATEGORIA_ENFERMEDAD = db.SUBCATEGORIA_ENFERMEDAD.Find(id);
            if (sUBCATEGORIA_ENFERMEDAD == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria = new SelectList(db.CATEGORIA_ENFERMEDAD, "IDCategEnf", "nombre", sUBCATEGORIA_ENFERMEDAD.categoria);
            return View(sUBCATEGORIA_ENFERMEDAD);
        }

        // POST: SUBCATEGORIA_ENFERMEDAD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSubEnf,nombre,categoria")] SUBCATEGORIA_ENFERMEDAD sUBCATEGORIA_ENFERMEDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUBCATEGORIA_ENFERMEDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.CATEGORIA_ENFERMEDAD, "IDCategEnf", "nombre", sUBCATEGORIA_ENFERMEDAD.categoria);
            return View(sUBCATEGORIA_ENFERMEDAD);
        }

        // GET: SUBCATEGORIA_ENFERMEDAD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORIA_ENFERMEDAD sUBCATEGORIA_ENFERMEDAD = db.SUBCATEGORIA_ENFERMEDAD.Find(id);
            if (sUBCATEGORIA_ENFERMEDAD == null)
            {
                return HttpNotFound();
            }
            return View(sUBCATEGORIA_ENFERMEDAD);
        }

        // POST: SUBCATEGORIA_ENFERMEDAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUBCATEGORIA_ENFERMEDAD sUBCATEGORIA_ENFERMEDAD = db.SUBCATEGORIA_ENFERMEDAD.Find(id);
            db.SUBCATEGORIA_ENFERMEDAD.Remove(sUBCATEGORIA_ENFERMEDAD);
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
