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
    public class GRUPO_CLASEController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: GRUPO_CLASE
        public ActionResult Index()
        {
            var gRUPO_CLASE = db.GRUPO_CLASE.Include(g => g.PERIODO1).Include(g => g.TUTOR1);
            return View(gRUPO_CLASE.ToList());
        }

        // GET: GRUPO_CLASE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPO_CLASE gRUPO_CLASE = db.GRUPO_CLASE.Find(id);
            if (gRUPO_CLASE == null)
            {
                return HttpNotFound();
            }
            return View(gRUPO_CLASE);
        }

        // GET: GRUPO_CLASE/Create
        public ActionResult Create()
        {
            ViewBag.PERIODO = new SelectList(db.PERIODO, "IDPERIODO", "NOMBRE");
            ViewBag.TUTOR = new SelectList(db.TUTOR, "IDTutor", "nombres");
            return View();
        }

        // POST: GRUPO_CLASE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDgrupo,descripcion,AÑO,PERIODO,TUTOR")] GRUPO_CLASE gRUPO_CLASE)
        {
            if (ModelState.IsValid)
            {
                db.GRUPO_CLASE.Add(gRUPO_CLASE);
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }

            ViewBag.PERIODO = new SelectList(db.PERIODO, "IDPERIODO", "NOMBRE", gRUPO_CLASE.PERIODO);
            ViewBag.TUTOR = new SelectList(db.TUTOR, "IDTutor", "nombres", gRUPO_CLASE.TUTOR);
            return View(gRUPO_CLASE);
        }

        // GET: GRUPO_CLASE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPO_CLASE gRUPO_CLASE = db.GRUPO_CLASE.Find(id);
            if (gRUPO_CLASE == null)
            {
                return HttpNotFound();
            }
            ViewBag.PERIODO = new SelectList(db.PERIODO, "IDPERIODO", "NOMBRE", gRUPO_CLASE.PERIODO);
            ViewBag.TUTOR = new SelectList(db.TUTOR, "IDTutor", "nombres", gRUPO_CLASE.TUTOR);
            return View(gRUPO_CLASE);
        }

        // POST: GRUPO_CLASE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDgrupo,descripcion,AÑO,PERIODO,TUTOR")] GRUPO_CLASE gRUPO_CLASE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gRUPO_CLASE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }
            ViewBag.PERIODO = new SelectList(db.PERIODO, "IDPERIODO", "NOMBRE", gRUPO_CLASE.PERIODO);
            ViewBag.TUTOR = new SelectList(db.TUTOR, "IDTutor", "nombres", gRUPO_CLASE.TUTOR);
            return View(gRUPO_CLASE);
        }

        // GET: GRUPO_CLASE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPO_CLASE gRUPO_CLASE = db.GRUPO_CLASE.Find(id);
            if (gRUPO_CLASE == null)
            {
                return HttpNotFound();
            }
            return View(gRUPO_CLASE);
        }

        // POST: GRUPO_CLASE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GRUPO_CLASE gRUPO_CLASE = db.GRUPO_CLASE.Find(id);
            db.GRUPO_CLASE.Remove(gRUPO_CLASE);
            db.SaveChanges();
            return RedirectToAction("SearchIndex");
        }
        public ActionResult SearchIndex(string searchString)
        {

            var grupos = from m in db.GRUPO_CLASE
                        select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                grupos = grupos.Where(a => a.descripcion.Contains(searchString));
                
            }
            return View(grupos);
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
