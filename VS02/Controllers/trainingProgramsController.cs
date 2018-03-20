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
    public class trainingProgramsController : Controller
    {
        private VS02Context db = new VS02Context();

        // GET: trainingPrograms
        public ActionResult Index()
        {
            var trainingPrograms = db.trainingPrograms.Include(t => t.Specialty);
            return View(trainingPrograms.ToList());
        }

        // GET: trainingPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainingProgram trainingProgram = db.trainingPrograms.Find(id);
            if (trainingProgram == null)
            {
                return HttpNotFound();
            }
            return View(trainingProgram);
        }

        // GET: trainingPrograms/Create
        public ActionResult Create()
        {
            ViewBag.IdSpecialty = new SelectList(db.Specialties, "IdSpecialty", "name");
            return View();
        }

        // POST: trainingPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTrainingProgram,name,acronym,IdSpecialty,status")] trainingProgram trainingProgram)
        {
            if (ModelState.IsValid)
            {
                db.trainingPrograms.Add(trainingProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSpecialty = new SelectList(db.Specialties, "IdSpecialty", "name", trainingProgram.IdSpecialty);
            return View(trainingProgram);
        }

        // GET: trainingPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainingProgram trainingProgram = db.trainingPrograms.Find(id);
            if (trainingProgram == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSpecialty = new SelectList(db.Specialties, "IdSpecialty", "name", trainingProgram.IdSpecialty);
            return View(trainingProgram);
        }

        // POST: trainingPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTrainingProgram,name,acronym,IdSpecialty,status")] trainingProgram trainingProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSpecialty = new SelectList(db.Specialties, "IdSpecialty", "name", trainingProgram.IdSpecialty);
            return View(trainingProgram);
        }

        // GET: trainingPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainingProgram trainingProgram = db.trainingPrograms.Find(id);
            if (trainingProgram == null)
            {
                return HttpNotFound();
            }
            return View(trainingProgram);
        }

        // POST: trainingPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trainingProgram trainingProgram = db.trainingPrograms.Find(id);
            db.trainingPrograms.Remove(trainingProgram);
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
