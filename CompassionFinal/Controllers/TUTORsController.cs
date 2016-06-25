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
    public class TUTORsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: TUTORs
        public ActionResult Index()
        {
            var tUTOR = db.TUTOR.Include(t => t.ESTADO1).Include(t => t.GRADO_INSTRUCCION1);
            return View(tUTOR.ToList());
        }

        // GET: TUTORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUTOR tUTOR = db.TUTOR.Find(id);
            if (tUTOR == null)
            {
                return HttpNotFound();
            }
            return View(tUTOR);
        }

        // GET: TUTORs/Create
        public ActionResult Create()
        {
            ViewBag.estado = new SelectList(db.ESTADO, "IDEstado", "detalle");
            ViewBag.grado_instruccion = new SelectList(db.GRADO_INSTRUCCION, "IDgrado", "nombres");
            return View();
        }

        // POST: TUTORs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTutor,nombres,apellidos,telefono,grado_instruccion,fecha_inicio_voluntariado,estado")] TUTOR tUTOR)
        {
            if (ModelState.IsValid)
            {
                db.TUTOR.Add(tUTOR);
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }

            ViewBag.estado = new SelectList(db.ESTADO, "IDEstado", "detalle", tUTOR.estado);
            ViewBag.grado_instruccion = new SelectList(db.GRADO_INSTRUCCION, "IDgrado", "nombres", tUTOR.grado_instruccion);
            return View(tUTOR);
        }

        // GET: TUTORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUTOR tUTOR = db.TUTOR.Find(id);
            if (tUTOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.estado = new SelectList(db.ESTADO, "IDEstado", "detalle", tUTOR.estado);
            ViewBag.grado_instruccion = new SelectList(db.GRADO_INSTRUCCION, "IDgrado", "nombres", tUTOR.grado_instruccion);
            return View(tUTOR);
        }

        // POST: TUTORs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTutor,nombres,apellidos,telefono,grado_instruccion,fecha_inicio_voluntariado,estado")] TUTOR tUTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tUTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }
            ViewBag.estado = new SelectList(db.ESTADO, "IDEstado", "detalle", tUTOR.estado);
            ViewBag.grado_instruccion = new SelectList(db.GRADO_INSTRUCCION, "IDgrado", "nombres", tUTOR.grado_instruccion);
            return View(tUTOR);
        }

        // GET: TUTORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUTOR tUTOR = db.TUTOR.Find(id);
            if (tUTOR == null)
            {
                return HttpNotFound();
            }
            return View(tUTOR);
        }

        // POST: TUTORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TUTOR tUTOR = db.TUTOR.Find(id);
            db.TUTOR.Remove(tUTOR);
            db.SaveChanges();
            return RedirectToAction("SearchIndex");
        }
        public ActionResult SearchIndex(string searchString)
        {

            var tutor = from m in db.TUTOR
                        select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                tutor = tutor.Where(s => s.apellidos.Contains(searchString));
            }
            return View(tutor);
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
