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
    [Authorize]
    public class training_course_typeController : Controller
    {
        private Entities db = new Entities();

        // GET: training_course_type
        public ActionResult Index()
        {
            return View(db.training_course_type.ToList());
        }

        // GET: training_course_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course_type training_course_type = db.training_course_type.Find(id);
            if (training_course_type == null)
            {
                return HttpNotFound();
            }
            return View(training_course_type);
        }

        // GET: training_course_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: training_course_type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Training_Course_Type_ID,Course_Name,Course_Description")] training_course_type training_course_type)
        {
            if (ModelState.IsValid)
            {
                db.training_course_type.Add(training_course_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(training_course_type);
        }

        // GET: training_course_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course_type training_course_type = db.training_course_type.Find(id);
            if (training_course_type == null)
            {
                return HttpNotFound();
            }
            return View(training_course_type);
        }

        // POST: training_course_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Training_Course_Type_ID,Course_Name,Course_Description")] training_course_type training_course_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(training_course_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(training_course_type);
        }

        // GET: training_course_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course_type training_course_type = db.training_course_type.Find(id);
            if (training_course_type == null)
            {
                return HttpNotFound();
            }
            return View(training_course_type);
        }

        // POST: training_course_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            training_course_type training_course_type = db.training_course_type.Find(id);
            db.training_course_type.Remove(training_course_type);
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
