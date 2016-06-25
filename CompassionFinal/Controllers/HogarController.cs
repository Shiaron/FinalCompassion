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
    public class HogarController : Controller
    {
        private Entities1 db = new Entities1();
        private Hogar hogar = new Hogar();

        // GET: Hogar
        public ActionResult Index()
        {
            return View(db.Hogar.ToList());
        }

        // GET: Hogar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hogar hogar = db.Hogar.Find(id);
            if (hogar == null)
            {
                return HttpNotFound();
            }
            return View(hogar);
        }

        // GET: Hogar/Create
        public ActionResult Create()
        {
            ViewBag.Hogar = hogar.Todo();
            return View();
        }

        // POST: Hogar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idhogar,nombre")] Hogar hogar)
        {
            if (ModelState.IsValid)
            {
                db.Hogar.Add(hogar);
                db.SaveChanges();
                return RedirectToAction("Create", "miembros_hogar");
            }

            return View(hogar);
        }

        // GET: Hogar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hogar hogar = db.Hogar.Find(id);
            if (hogar == null)
            {
                return HttpNotFound();
            }
            return View(hogar);
        }

        // POST: Hogar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idhogar,nombre")] Hogar hogar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hogar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hogar);
        }

        // GET: Hogar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hogar hogar = db.Hogar.Find(id);
            if (hogar == null)
            {
                return HttpNotFound();
            }
            return View(hogar);
        }

        // POST: Hogar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hogar hogar = db.Hogar.Find(id);
            db.Hogar.Remove(hogar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SearchIndex(string searchString)
        {

            var hogar = from m in db.Hogar
                        select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                hogar = hogar.Where(s => s.nombre.Contains(searchString));
            }
            return View(hogar);
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
