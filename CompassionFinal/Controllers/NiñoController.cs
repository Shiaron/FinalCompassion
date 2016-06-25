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
    public class NiñoController : Controller
    {
        private Entities1 db = new Entities1();
        private Niño niño = new Niño();
        // GET: Niño
        public ActionResult Index()
        {
            var niño = db.Niño.Include(n => n.genero1).Include(n => n.GRUPO_CLASE1).Include(n => n.Hogar).Include(n => n.Nivel1);
            return View(niño.ToList());
        }
        public ActionResult Find(string id)
        {
            if (id == null)
            {
                return View();
            }
            Niño niño = db.Niño.Find(id);
            if (niño == null)
            {
                return View();
            }
            return View(niño);
        }
        // GET: Niño/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niño niño = db.Niño.Find(id);
            if (niño == null)
            {
                return HttpNotFound();
            }
            return View(niño);
        }

        // GET: Niño/Create
        public ActionResult Create()
        {
            ViewBag.Genero = new SelectList(db.genero, "Idgenero", "detalle");
            ViewBag.Grupo_clase = new SelectList(db.GRUPO_CLASE, "IDgrupo", "descripcion");
            ViewBag.Idhogar = new SelectList(db.Hogar, "Idhogar", "nombre");
            ViewBag.nivel = new SelectList(db.Nivel, "Idnivel", "nombre");
            return View();
        }

        // POST: Niño/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idniño,Nombres,Idhogar,Genero,DNI,fechanacimiento,nivel,direccion,Grupo_clase")] Niño niño)
        {
            if (ModelState.IsValid)
            {
                db.Niño.Add(niño);
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }

            ViewBag.Genero = new SelectList(db.genero, "Idgenero", "detalle", niño.Genero);
            ViewBag.Grupo_clase = new SelectList(db.GRUPO_CLASE, "IDgrupo", "descripcion", niño.Grupo_clase);
            ViewBag.Idhogar = new SelectList(db.Hogar, "Idhogar", "nombre", niño.Idhogar);
            ViewBag.nivel = new SelectList(db.Nivel, "Idnivel", "nombre", niño.nivel);
            return View(niño);
        }

        // GET: Niño/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niño niño = db.Niño.Find(id);
            if (niño == null)
            {
                return HttpNotFound();
            }
            ViewBag.Genero = new SelectList(db.genero, "Idgenero", "detalle", niño.Genero);
            ViewBag.Grupo_clase = new SelectList(db.GRUPO_CLASE, "IDgrupo", "descripcion", niño.Grupo_clase);
            ViewBag.Idhogar = new SelectList(db.Hogar, "Idhogar", "nombre", niño.Idhogar);
            ViewBag.nivel = new SelectList(db.Nivel, "Idnivel", "nombre", niño.nivel);
            return View(niño);
        }

        // POST: Niño/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idniño,Nombres,Idhogar,Genero,DNI,fechanacimiento,nivel,direccion,Grupo_clase")] Niño niño)
        {
            if (ModelState.IsValid)
            {
                db.Entry(niño).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }
            ViewBag.Genero = new SelectList(db.genero, "Idgenero", "detalle", niño.Genero);
            ViewBag.Grupo_clase = new SelectList(db.GRUPO_CLASE, "IDgrupo", "descripcion", niño.Grupo_clase);
            ViewBag.Idhogar = new SelectList(db.Hogar, "Idhogar", "nombre", niño.Idhogar);
            ViewBag.nivel = new SelectList(db.Nivel, "Idnivel", "nombre", niño.nivel);
            return View(niño);
        }

        // GET: Niño/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niño niño = db.Niño.Find(id);
            if (niño == null)
            {
                return HttpNotFound();
            }
            return View(niño);
        }

        // POST: Niño/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Niño niño = db.Niño.Find(id);
            db.Niño.Remove(niño);
            db.SaveChanges();
            return RedirectToAction("SearchIndex");
        }

        
        public ActionResult SearchIndex(string searchString)
        {

            var niños = from m in db.Niño
                        select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                niños = niños.Where(s => s.Idniño.Contains(searchString));
            }
            return View(niños);
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
