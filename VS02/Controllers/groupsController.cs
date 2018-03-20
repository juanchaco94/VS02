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
    public class groupsController : Controller
    {
        private VS02Context db = new VS02Context();

        // GET: groups
        public ActionResult Index()
        {
            var groups = db.groups.Include(g => g.ambient).Include(g => g.data).Include(g => g.trimester);
            return View(groups.ToList());
        }

        // GET: groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            group group = db.groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: groups/Create
        public ActionResult Create()
        {
            ViewBag.IdAmbient = new SelectList(db.ambients, "IdAmbient", "name");
            ViewBag.IdData = new SelectList(db.data, "IdData", "numberData");
            ViewBag.IdTrimester = new SelectList(db.trimesters, "IdTrimester", "name");
            return View();
        }

        // POST: groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGroup,name,IdData,IdAmbient,IdTrimester")] group group)
        {
            if (ModelState.IsValid)
            {
                db.groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAmbient = new SelectList(db.ambients, "IdAmbient", "name", group.IdAmbient);
            ViewBag.IdData = new SelectList(db.data, "IdData", "numberData", group.IdData);
            ViewBag.IdTrimester = new SelectList(db.trimesters, "IdTrimester", "name", group.IdTrimester);
            return View(group);
        }

        // GET: groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            group group = db.groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAmbient = new SelectList(db.ambients, "IdAmbient", "name", group.IdAmbient);
            ViewBag.IdData = new SelectList(db.data, "IdData", "numberData", group.IdData);
            ViewBag.IdTrimester = new SelectList(db.trimesters, "IdTrimester", "name", group.IdTrimester);
            return View(group);
        }

        // POST: groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGroup,name,IdData,IdAmbient,IdTrimester")] group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAmbient = new SelectList(db.ambients, "IdAmbient", "name", group.IdAmbient);
            ViewBag.IdData = new SelectList(db.data, "IdData", "numberData", group.IdData);
            ViewBag.IdTrimester = new SelectList(db.trimesters, "IdTrimester", "name", group.IdTrimester);
            return View(group);
        }

        // GET: groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            group group = db.groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            group group = db.groups.Find(id);
            db.groups.Remove(group);
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
