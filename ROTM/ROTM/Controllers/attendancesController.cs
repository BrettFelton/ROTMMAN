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
    public class attendancesController : Controller
    {
        private Entities db = new Entities();

        // GET: attendances
        public ActionResult Index()
        {
            var attendances = db.attendances.Include(a => a.training_course_instance).Include(a => a.employee);
            return View(attendances.ToList());
        }

        // GET: attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: attendances/Create
        public ActionResult Create()
        {
            ViewBag.Training_Course_Instance_ID = new SelectList(db.training_course_instance, "Training_Course_Instance_ID", "Training_Course_Instance_ID");
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name");
            return View();
        }

        // POST: attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Training_Course_Instance_ID,Employee_ID,Replied_Going,Actual_Attendance")] attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Training_Course_Instance_ID = new SelectList(db.training_course_instance, "Training_Course_Instance_ID", "Training_Course_Instance_ID", attendance.Training_Course_Instance_ID);
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", attendance.Employee_ID);
            return View(attendance);
        }

        // GET: attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Training_Course_Instance_ID = new SelectList(db.training_course_instance, "Training_Course_Instance_ID", "Training_Course_Instance_ID", attendance.Training_Course_Instance_ID);
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", attendance.Employee_ID);
            return View(attendance);
        }

        // POST: attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Training_Course_Instance_ID,Employee_ID,Replied_Going,Actual_Attendance")] attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Training_Course_Instance_ID = new SelectList(db.training_course_instance, "Training_Course_Instance_ID", "Training_Course_Instance_ID", attendance.Training_Course_Instance_ID);
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", attendance.Employee_ID);
            return View(attendance);
        }

        // GET: attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            attendance attendance = db.attendances.Find(id);
            db.attendances.Remove(attendance);
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
