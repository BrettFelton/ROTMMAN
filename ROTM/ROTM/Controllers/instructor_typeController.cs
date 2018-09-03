using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ROTM;

namespace ROTM.Controllers
{
    public class instructor_typeController : Controller
    {
        private Entities db = new Entities();

        // GET: instructor_type
        public ActionResult Index()
        {
            return View(db.instructor_type.ToList());
        }

        // GET: instructor_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor_type instructor_type = db.instructor_type.Find(id);
            if (instructor_type == null)
            {
                return HttpNotFound();
            }
            return View(instructor_type);
        }

        // GET: instructor_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: instructor_type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Instructor_Type_ID,Instructor_Type_Name,Instrutor_Type_Description")] instructor_type instructor_type)
        {
            if (ModelState.IsValid)
            {
                db.instructor_type.Add(instructor_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instructor_type);
        }

        // GET: instructor_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor_type instructor_type = db.instructor_type.Find(id);
            if (instructor_type == null)
            {
                return HttpNotFound();
            }
            return View(instructor_type);
        }

        // POST: instructor_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Instructor_Type_ID,Instructor_Type_Name,Instrutor_Type_Description")] instructor_type instructor_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instructor_type);
        }

        // GET: instructor_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor_type instructor_type = db.instructor_type.Find(id);
            if (instructor_type == null)
            {
                return HttpNotFound();
            }
            return View(instructor_type);
        }

        // POST: instructor_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            instructor_type instructor_type = db.instructor_type.Find(id);
            db.instructor_type.Remove(instructor_type);
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
