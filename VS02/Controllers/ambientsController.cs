using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VS02.Models;

namespace VS02.Controllers
{
    public class ambientsController : Controller
    {
        private VS02Context db = new VS02Context();

        // GET: ambients
        public ActionResult Index()
        {
            var ambients = db.ambients.Include(a => a.Seat);
            return View(ambients.ToList());
        }

        // GET: ambients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ambient ambient = db.ambients.Find(id);
            if (ambient == null)
            {
                return HttpNotFound();
            }
            return View(ambient);
        }

        // GET: ambients/Create
        public ActionResult Create()
        {
            ViewBag.IdSeat = new SelectList(db.Seats, "IdSeat", "name");
            return View();
        }

        // POST: ambients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAmbient,name,IdSeat,status")] ambient ambient)
        {
            if (ModelState.IsValid)
            {
                db.ambients.Add(ambient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSeat = new SelectList(db.Seats, "IdSeat", "name", ambient.IdSeat);
            return View(ambient);
        }

        // GET: ambients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ambient ambient = db.ambients.Find(id);
            if (ambient == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSeat = new SelectList(db.Seats, "IdSeat", "name", ambient.IdSeat);
            return View(ambient);
        }

        // POST: ambients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAmbient,name,IdSeat,status")] ambient ambient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ambient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSeat = new SelectList(db.Seats, "IdSeat", "name", ambient.IdSeat);
            return View(ambient);
        }

        // GET: ambients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ambient ambient = db.ambients.Find(id);
            if (ambient == null)
            {
                return HttpNotFound();
            }
            return View(ambient);
        }

        // POST: ambients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ambient ambient = db.ambients.Find(id);
            db.ambients.Remove(ambient);
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
