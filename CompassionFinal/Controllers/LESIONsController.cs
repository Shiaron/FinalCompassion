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
    public class LESIONsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: LESIONs
        public ActionResult Index()
        {
            return View(db.LESION.ToList());
        }

        // GET: LESIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LESION lESION = db.LESION.Find(id);
            if (lESION == null)
            {
                return HttpNotFound();
            }
            return View(lESION);
        }

        // GET: LESIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LESIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLesion,nombre")] LESION lESION)
        {
            if (ModelState.IsValid)
            {
                db.LESION.Add(lESION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lESION);
        }

        // GET: LESIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LESION lESION = db.LESION.Find(id);
            if (lESION == null)
            {
                return HttpNotFound();
            }
            return View(lESION);
        }

        // POST: LESIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLesion,nombre")] LESION lESION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lESION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lESION);
        }

        // GET: LESIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LESION lESION = db.LESION.Find(id);
            if (lESION == null)
            {
                return HttpNotFound();
            }
            return View(lESION);
        }

        // POST: LESIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LESION lESION = db.LESION.Find(id);
            db.LESION.Remove(lESION);
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
