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
    public class miembros_hogarController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: miembros_hogar
        public ActionResult Index()
        {
            var miembros_hogar = db.miembros_hogar.Include(m => m.Hogar).Include(m => m.Rol);
            return View(miembros_hogar.ToList());
        }

        // GET: miembros_hogar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            miembros_hogar miembros_hogar = db.miembros_hogar.Find(id);
            if (miembros_hogar == null)
            {
                return HttpNotFound();
            }
            return View(miembros_hogar);
        }

        // GET: miembros_hogar/Create
        public ActionResult Create()
        {
            ViewBag.idhogar = new SelectList(db.Hogar, "Idhogar", "nombre");
            ViewBag.idrol = new SelectList(db.Rol, "Idrol", "nombre");
            return View();
        }

        // POST: miembros_hogar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idmiembro,idhogar,nombres,idrol,cuidador")] miembros_hogar miembros_hogar)
        {
            if (ModelState.IsValid)
            {
                db.miembros_hogar.Add(miembros_hogar);
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }

            ViewBag.idhogar = new SelectList(db.Hogar, "Idhogar", "nombre", miembros_hogar.idhogar);
            ViewBag.idrol = new SelectList(db.Rol, "Idrol", "nombre", miembros_hogar.idrol);
            return View(miembros_hogar);
        }

        // GET: miembros_hogar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            miembros_hogar miembros_hogar = db.miembros_hogar.Find(id);
            if (miembros_hogar == null)
            {
                return HttpNotFound();
            }
            ViewBag.idhogar = new SelectList(db.Hogar, "Idhogar", "nombre", miembros_hogar.idhogar);
            ViewBag.idrol = new SelectList(db.Rol, "Idrol", "nombre", miembros_hogar.idrol);
            return View(miembros_hogar);
        }

        // POST: miembros_hogar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idmiembro,idhogar,nombres,idrol,cuidador")] miembros_hogar miembros_hogar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miembros_hogar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }
            ViewBag.idhogar = new SelectList(db.Hogar, "Idhogar", "nombre", miembros_hogar.idhogar);
            ViewBag.idrol = new SelectList(db.Rol, "Idrol", "nombre", miembros_hogar.idrol);
            return View(miembros_hogar);
        }

        // GET: miembros_hogar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            miembros_hogar miembros_hogar = db.miembros_hogar.Find(id);
            if (miembros_hogar == null)
            {
                return HttpNotFound();
            }
            return View(miembros_hogar);
        }

        // POST: miembros_hogar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            miembros_hogar miembros_hogar = db.miembros_hogar.Find(id);
            db.miembros_hogar.Remove(miembros_hogar);
            db.SaveChanges();
            return RedirectToAction("SearchIndex");
        }
        public ActionResult SearchIndex(string searchString)
        {

            var miembros = from m in db.miembros_hogar
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                miembros = miembros.Where(s => s.Hogar.nombre.Contains(searchString));
            }
            return View(miembros);
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
