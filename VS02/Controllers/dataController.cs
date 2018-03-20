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
    public class dataController : Controller
    {
        private VS02Context db = new VS02Context();

        // GET: data
        public ActionResult Index()
        {
            var data = db.data.Include(d => d.trainingProgram).Include(d => d.workingDay);
            return View(data.ToList());
        }

        // GET: data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            data data = db.data.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // GET: data/Create
        public ActionResult Create()
        {
            ViewBag.IdTrainingProgram = new SelectList(db.trainingPrograms, "IdTrainingProgram", "name");
            ViewBag.IdWorkingDay = new SelectList(db.workingDays, "IdWorkingDay", "nombre");
            return View();
        }

        // POST: data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdData,numberData,IdWorkingDay,startDate,finishDate,IdTrainingProgram,status,description")] data data)
        {
            if (ModelState.IsValid)
            {
                db.data.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTrainingProgram = new SelectList(db.trainingPrograms, "IdTrainingProgram", "name", data.IdTrainingProgram);
            ViewBag.IdWorkingDay = new SelectList(db.workingDays, "IdWorkingDay", "nombre", data.IdWorkingDay);
            return View(data);
        }

        // GET: data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            data data = db.data.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTrainingProgram = new SelectList(db.trainingPrograms, "IdTrainingProgram", "name", data.IdTrainingProgram);
            ViewBag.IdWorkingDay = new SelectList(db.workingDays, "IdWorkingDay", "nombre", data.IdWorkingDay);
            return View(data);
        }

        // POST: data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdData,numberData,IdWorkingDay,startDate,finishDate,IdTrainingProgram,status,description")] data data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTrainingProgram = new SelectList(db.trainingPrograms, "IdTrainingProgram", "name", data.IdTrainingProgram);
            ViewBag.IdWorkingDay = new SelectList(db.workingDays, "IdWorkingDay", "nombre", data.IdWorkingDay);
            return View(data);
        }

        // GET: data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            data data = db.data.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            data data = db.data.Find(id);
            db.data.Remove(data);
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
