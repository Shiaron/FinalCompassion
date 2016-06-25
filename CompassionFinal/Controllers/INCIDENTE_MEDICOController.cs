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
    public class INCIDENTE_MEDICOController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: INCIDENTE_MEDICO
        public ActionResult Index()
        {
            var iNCIDENTE_MEDICO = db.INCIDENTE_MEDICO.Include(i => i.Niño).Include(i => i.Tipo1);
            return View(iNCIDENTE_MEDICO.ToList());
        }

        // GET: INCIDENTE_MEDICO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCIDENTE_MEDICO iNCIDENTE_MEDICO = db.INCIDENTE_MEDICO.Find(id);
            if (iNCIDENTE_MEDICO == null)
            {
                return HttpNotFound();
            }
            return View(iNCIDENTE_MEDICO);
        }

        // GET: INCIDENTE_MEDICO/Create
        public ActionResult Create()
        {
            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres");
            ViewBag.tipo = new SelectList(db.Tipo, "IDtipo", "nombre");
            return View();
        }

        // POST: INCIDENTE_MEDICO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDincidente,idniño,fecha,tipo,monto_desembolsado")] INCIDENTE_MEDICO iNCIDENTE_MEDICO)
        {
            if (ModelState.IsValid)
            {
                db.INCIDENTE_MEDICO.Add(iNCIDENTE_MEDICO);
                db.SaveChanges();
                if (iNCIDENTE_MEDICO.tipo == 1)
                {
                    return RedirectToAction("Create", "DETALLE_ENFERMEDAD");
                }
                else
                {
                    return RedirectToAction("Create", "DETALLE_LESION");
                }

            }

            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres", iNCIDENTE_MEDICO.idniño);
            ViewBag.tipo = new SelectList(db.Tipo, "IDtipo", "nombre", iNCIDENTE_MEDICO.tipo);
            return View(iNCIDENTE_MEDICO);
        }

        // GET: INCIDENTE_MEDICO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCIDENTE_MEDICO iNCIDENTE_MEDICO = db.INCIDENTE_MEDICO.Find(id);
            if (iNCIDENTE_MEDICO == null)
            {
                return HttpNotFound();
            }
            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres", iNCIDENTE_MEDICO.idniño);
            ViewBag.tipo = new SelectList(db.Tipo, "IDtipo", "nombre", iNCIDENTE_MEDICO.tipo);
            return View(iNCIDENTE_MEDICO);
        }

        // POST: INCIDENTE_MEDICO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDincidente,idniño,fecha,tipo,monto_desembolsado")] INCIDENTE_MEDICO iNCIDENTE_MEDICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNCIDENTE_MEDICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }
            ViewBag.idniño = new SelectList(db.Niño, "Idniño", "Nombres", iNCIDENTE_MEDICO.idniño);
            ViewBag.tipo = new SelectList(db.Tipo, "IDtipo", "nombre", iNCIDENTE_MEDICO.tipo);
            return View(iNCIDENTE_MEDICO);
        }

        // GET: INCIDENTE_MEDICO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCIDENTE_MEDICO iNCIDENTE_MEDICO = db.INCIDENTE_MEDICO.Find(id);
            if (iNCIDENTE_MEDICO == null)
            {
                return HttpNotFound();
            }
            return View(iNCIDENTE_MEDICO);
        }

        // POST: INCIDENTE_MEDICO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INCIDENTE_MEDICO iNCIDENTE_MEDICO = db.INCIDENTE_MEDICO.Find(id);
            db.INCIDENTE_MEDICO.Remove(iNCIDENTE_MEDICO);
            db.SaveChanges();
            return RedirectToAction("SearchIndex");
        }
        public ActionResult SearchIndex(string searchString)
        {

            var incidente = from m in db.INCIDENTE_MEDICO
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                incidente = incidente.Where(s => s.idniño.Contains(searchString));

            }
            return View(incidente);
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
