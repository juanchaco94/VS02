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
    public class gendersController : Controller
    {
        private VS02Context db = new VS02Context();

        // GET: genders
        public ActionResult Index()
        {
            return View(db.genders.ToList());
        }

        // GET: genders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gender gender = db.genders.Find(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        // GET: genders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: genders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGender,description,status")] gender gender)
        {
            if (ModelState.IsValid)
            {
                db.genders.Add(gender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gender);
        }

        // GET: genders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gender gender = db.genders.Find(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        // POST: genders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGender,description,status")] gender gender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gender);
        }

        // GET: genders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gender gender = db.genders.Find(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        // POST: genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gender gender = db.genders.Find(id);
            db.genders.Remove(gender);
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
