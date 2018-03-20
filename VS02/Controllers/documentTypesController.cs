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
    public class documentTypesController : Controller
    {
        private VS02Context db = new VS02Context();

        // GET: documentTypes
        public ActionResult Index()
        {
            return View(db.documentTypes.ToList());
        }

        // GET: documentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documentType documentType = db.documentTypes.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }

        // GET: documentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: documentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDocumentType,description,status")] documentType documentType)
        {
            if (ModelState.IsValid)
            {
                db.documentTypes.Add(documentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(documentType);
        }

        // GET: documentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documentType documentType = db.documentTypes.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }

        // POST: documentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDocumentType,description,status")] documentType documentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(documentType);
        }

        // GET: documentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documentType documentType = db.documentTypes.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }

        // POST: documentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            documentType documentType = db.documentTypes.Find(id);
            db.documentTypes.Remove(documentType);
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
