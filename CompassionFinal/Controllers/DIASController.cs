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
    public class DIASController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: DIAS
        public ActionResult Index()
        {
            return View(db.DIAS.ToList());
        }

        // GET: DIAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIAS dIAS = db.DIAS.Find(id);
            if (dIAS == null)
            {
                return HttpNotFound();
            }
            return View(dIAS);
        }

        // GET: DIAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DIAS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDIAS,nombre")] DIAS dIAS)
        {
            if (ModelState.IsValid)
            {
                db.DIAS.Add(dIAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dIAS);
        }

        // GET: DIAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIAS dIAS = db.DIAS.Find(id);
            if (dIAS == null)
            {
                return HttpNotFound();
            }
            return View(dIAS);
        }

        // POST: DIAS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDIAS,nombre")] DIAS dIAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dIAS);
        }

        // GET: DIAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIAS dIAS = db.DIAS.Find(id);
            if (dIAS == null)
            {
                return HttpNotFound();
            }
            return View(dIAS);
        }

        // POST: DIAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIAS dIAS = db.DIAS.Find(id);
            db.DIAS.Remove(dIAS);
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
