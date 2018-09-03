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
    public class training_course_instanceController : Controller
    {
        private Entities db = new Entities();

        // GET: training_course_instance
        public ActionResult Index()
        {
            var training_course_instance = db.training_course_instance.Include(t => t.training_course).Include(t => t.venue).Include(t => t.instructor);
            return View(training_course_instance.ToList());
        }

        // GET: training_course_instance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course_instance training_course_instance = db.training_course_instance.Find(id);
            if (training_course_instance == null)
            {
                return HttpNotFound();
            }
            return View(training_course_instance);
        }

        // GET: training_course_instance/Create
        public ActionResult Create()
        {
            ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name");
            ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name");
            ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name");
            return View();
        }

        // POST: training_course_instance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Training_Course_Instance_ID,Instance_Date,Instance_Start_Time,Instance_End_Time,Venue_ID,Instructor_ID,Training_Course_ID")] training_course_instance training_course_instance)
        {
            if (ModelState.IsValid)
            {
                db.training_course_instance.Add(training_course_instance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name", training_course_instance.Training_Course_ID);
            ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name", training_course_instance.Venue_ID);
            ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name", training_course_instance.Instructor_ID);
            return View(training_course_instance);
        }

        // GET: training_course_instance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course_instance training_course_instance = db.training_course_instance.Find(id);
            if (training_course_instance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name", training_course_instance.Training_Course_ID);
            ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name", training_course_instance.Venue_ID);
            ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name", training_course_instance.Instructor_ID);
            return View(training_course_instance);
        }

        // POST: training_course_instance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Training_Course_Instance_ID,Instance_Date,Instance_Start_Time,Instance_End_Time,Venue_ID,Instructor_ID,Training_Course_ID")] training_course_instance training_course_instance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(training_course_instance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name", training_course_instance.Training_Course_ID);
            ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name", training_course_instance.Venue_ID);
            ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name", training_course_instance.Instructor_ID);
            return View(training_course_instance);
        }

        // GET: training_course_instance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course_instance training_course_instance = db.training_course_instance.Find(id);
            if (training_course_instance == null)
            {
                return HttpNotFound();
            }
            return View(training_course_instance);
        }

        // POST: training_course_instance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            training_course_instance training_course_instance = db.training_course_instance.Find(id);
            db.training_course_instance.Remove(training_course_instance);
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
