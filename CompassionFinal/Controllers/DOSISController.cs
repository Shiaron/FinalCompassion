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
    public class DOSISController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: DOSIS
        public ActionResult Index()
        {
            return View(db.DOSIS.ToList());
        }

        // GET: DOSIS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOSIS dOSIS = db.DOSIS.Find(id);
            if (dOSIS == null)
            {
                return HttpNotFound();
            }
            return View(dOSIS);
        }

        // GET: DOSIS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DOSIS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDosis,nombre")] DOSIS dOSIS)
        {
            if (ModelState.IsValid)
            {
                db.DOSIS.Add(dOSIS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dOSIS);
        }

        // GET: DOSIS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOSIS dOSIS = db.DOSIS.Find(id);
            if (dOSIS == null)
            {
                return HttpNotFound();
            }
            return View(dOSIS);
        }

        // POST: DOSIS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDosis,nombre")] DOSIS dOSIS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOSIS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOSIS);
        }

        // GET: DOSIS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOSIS dOSIS = db.DOSIS.Find(id);
            if (dOSIS == null)
            {
                return HttpNotFound();
            }
            return View(dOSIS);
        }

        // POST: DOSIS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOSIS dOSIS = db.DOSIS.Find(id);
            db.DOSIS.Remove(dOSIS);
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
