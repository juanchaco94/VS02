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
    public class trimestersController : Controller
    {
        private VS02Context db = new VS02Context();

        // GET: trimesters
        public ActionResult Index()
        {
            return View(db.trimesters.ToList());
        }

        // GET: trimesters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trimester trimester = db.trimesters.Find(id);
            if (trimester == null)
            {
                return HttpNotFound();
            }
            return View(trimester);
        }

        // GET: trimesters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: trimesters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTrimester,name")] trimester trimester)
        {
            if (ModelState.IsValid)
            {
                db.trimesters.Add(trimester);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trimester);
        }

        // GET: trimesters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trimester trimester = db.trimesters.Find(id);
            if (trimester == null)
            {
                return HttpNotFound();
            }
            return View(trimester);
        }

        // POST: trimesters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTrimester,name")] trimester trimester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trimester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trimester);
        }

        // GET: trimesters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trimester trimester = db.trimesters.Find(id);
            if (trimester == null)
            {
                return HttpNotFound();
            }
            return View(trimester);
        }

        // POST: trimesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trimester trimester = db.trimesters.Find(id);
            db.trimesters.Remove(trimester);
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
