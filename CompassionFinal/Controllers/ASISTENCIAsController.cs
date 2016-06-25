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
    public class ASISTENCIAsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: ASISTENCIAs
        public ActionResult Index()
        {
            var aSISTENCIA = db.ASISTENCIA.Include(a => a.Niño);
            return View(aSISTENCIA.ToList());
        }

        // GET: ASISTENCIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASISTENCIA aSISTENCIA = db.ASISTENCIA.Find(id);
            if (aSISTENCIA == null)
            {
                return HttpNotFound();
            }
            return View(aSISTENCIA);
        }

        // GET: ASISTENCIAs/Create
        public ActionResult Create()
        {
            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres");
            return View();
        }

        // POST: ASISTENCIAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDasistencia,idniño,fecha,asistencia1")] ASISTENCIA aSISTENCIA)
        {
            if (ModelState.IsValid)
            {
                db.ASISTENCIA.Add(aSISTENCIA);
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }

            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres", aSISTENCIA.idniño);
            return View(aSISTENCIA);
        }

        // GET: ASISTENCIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASISTENCIA aSISTENCIA = db.ASISTENCIA.Find(id);
            if (aSISTENCIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres", aSISTENCIA.idniño);
            return View(aSISTENCIA);
        }

        // POST: ASISTENCIAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDasistencia,idniño,fecha,asistencia1")] ASISTENCIA aSISTENCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSISTENCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }
            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres", aSISTENCIA.idniño);
            return View(aSISTENCIA);
        }

        // GET: ASISTENCIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASISTENCIA aSISTENCIA = db.ASISTENCIA.Find(id);
            if (aSISTENCIA == null)
            {
                return HttpNotFound();
            }
            return View(aSISTENCIA);
        }

        // POST: ASISTENCIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ASISTENCIA aSISTENCIA = db.ASISTENCIA.Find(id);
            db.ASISTENCIA.Remove(aSISTENCIA);
            db.SaveChanges();
            return RedirectToAction("SearchIndex");
        }
        public ActionResult SearchIndex(string searchString)
        {
            DateTime FechaBuscada = Convert.ToDateTime(searchString);
            var asistencia = from m in db.ASISTENCIA
                             select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                asistencia = asistencia.Where(s => s.fecha == FechaBuscada);
            }
            return View(asistencia);


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
