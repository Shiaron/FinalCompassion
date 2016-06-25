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
    public class CATEGORIA_ENFERMEDADController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: CATEGORIA_ENFERMEDAD
        public ActionResult Index()
        {
            return View(db.CATEGORIA_ENFERMEDAD.ToList());
        }

        // GET: CATEGORIA_ENFERMEDAD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_ENFERMEDAD cATEGORIA_ENFERMEDAD = db.CATEGORIA_ENFERMEDAD.Find(id);
            if (cATEGORIA_ENFERMEDAD == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_ENFERMEDAD);
        }

        // GET: CATEGORIA_ENFERMEDAD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATEGORIA_ENFERMEDAD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCategEnf,nombre")] CATEGORIA_ENFERMEDAD cATEGORIA_ENFERMEDAD)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIA_ENFERMEDAD.Add(cATEGORIA_ENFERMEDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEGORIA_ENFERMEDAD);
        }

        // GET: CATEGORIA_ENFERMEDAD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_ENFERMEDAD cATEGORIA_ENFERMEDAD = db.CATEGORIA_ENFERMEDAD.Find(id);
            if (cATEGORIA_ENFERMEDAD == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_ENFERMEDAD);
        }

        // POST: CATEGORIA_ENFERMEDAD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCategEnf,nombre")] CATEGORIA_ENFERMEDAD cATEGORIA_ENFERMEDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIA_ENFERMEDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEGORIA_ENFERMEDAD);
        }

        // GET: CATEGORIA_ENFERMEDAD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_ENFERMEDAD cATEGORIA_ENFERMEDAD = db.CATEGORIA_ENFERMEDAD.Find(id);
            if (cATEGORIA_ENFERMEDAD == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_ENFERMEDAD);
        }

        // POST: CATEGORIA_ENFERMEDAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORIA_ENFERMEDAD cATEGORIA_ENFERMEDAD = db.CATEGORIA_ENFERMEDAD.Find(id);
            db.CATEGORIA_ENFERMEDAD.Remove(cATEGORIA_ENFERMEDAD);
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
