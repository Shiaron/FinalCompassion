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
    public class ESTADOController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: ESTADO
        public ActionResult Index()
        {
            return View(db.ESTADO.ToList());
        }

        // GET: ESTADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO eSTADO = db.ESTADO.Find(id);
            if (eSTADO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO);
        }

        // GET: ESTADO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESTADO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEstado,detalle")] ESTADO eSTADO)
        {
            if (ModelState.IsValid)
            {
                db.ESTADO.Add(eSTADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eSTADO);
        }

        // GET: ESTADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO eSTADO = db.ESTADO.Find(id);
            if (eSTADO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO);
        }

        // POST: ESTADO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEstado,detalle")] ESTADO eSTADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSTADO);
        }

        // GET: ESTADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO eSTADO = db.ESTADO.Find(id);
            if (eSTADO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO);
        }

        // POST: ESTADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADO eSTADO = db.ESTADO.Find(id);
            db.ESTADO.Remove(eSTADO);
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
