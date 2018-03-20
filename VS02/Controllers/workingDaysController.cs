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
    public class workingDaysController : Controller
    {
        private VS02Context db = new VS02Context();

        // GET: workingDays
        public ActionResult Index()
        {
            return View(db.workingDays.ToList());
        }

        // GET: workingDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workingDay workingDay = db.workingDays.Find(id);
            if (workingDay == null)
            {
                return HttpNotFound();
            }
            return View(workingDay);
        }

        // GET: workingDays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: workingDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdWorkingDay,nombre")] workingDay workingDay)
        {
            if (ModelState.IsValid)
            {
                db.workingDays.Add(workingDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workingDay);
        }

        // GET: workingDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workingDay workingDay = db.workingDays.Find(id);
            if (workingDay == null)
            {
                return HttpNotFound();
            }
            return View(workingDay);
        }

        // POST: workingDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdWorkingDay,nombre")] workingDay workingDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workingDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workingDay);
        }

        // GET: workingDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workingDay workingDay = db.workingDays.Find(id);
            if (workingDay == null)
            {
                return HttpNotFound();
            }
            return View(workingDay);
        }

        // POST: workingDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            workingDay workingDay = db.workingDays.Find(id);
            db.workingDays.Remove(workingDay);
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
