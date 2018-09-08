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
    public class training_courseController : Controller
    {
        private Entities db = new Entities();

        // GET: training_course
        public ActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var training_course = from s in (db.training_course.Include(t => t.employee).Include(t => t.training_course_type)) select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                training_course = training_course.Where(s => s.Training_Course_Name.Contains(searchString) || s.Training_Course_Description.Contains(searchString));
            }
            //var training_course = db.training_course.Include(t => t.employee).Include(t => t.training_course_type);
            return View(training_course.ToList());
        }

        // GET: training_course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course training_course = db.training_course.Find(id);
            if (training_course == null)
            {
                return HttpNotFound();
            }
            return View(training_course);
        }

        // GET: training_course/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name");
            ViewBag.Training_Course_Type_ID = new SelectList(db.training_course_type, "Training_Course_Type_ID", "Course_Name");
            return View();
        }

        // POST: training_course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Training_Course_ID,Training_Course_Name,Training_Course_Description,Employee_ID,Training_Course_Type_ID")] training_course training_course)
        {
            bool val = Validate(training_course.Training_Course_Name);
            if (ModelState.IsValid && val == false)
            {
                db.training_course.Add(training_course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an: " + training_course.Training_Course_Name + " type in the database.";
                ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", training_course.Employee_ID);
                ViewBag.Training_Course_Type_ID = new SelectList(db.training_course_type, "Training_Course_Type_ID", "Course_Name", training_course.Training_Course_Type_ID);
                return View();
            }

            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", training_course.Employee_ID);
            ViewBag.Training_Course_Type_ID = new SelectList(db.training_course_type, "Training_Course_Type_ID", "Course_Name", training_course.Training_Course_Type_ID);
            return View(training_course);
        }

        // GET: training_course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course training_course = db.training_course.Find(id);
            if (training_course == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", training_course.Employee_ID);
            ViewBag.Training_Course_Type_ID = new SelectList(db.training_course_type, "Training_Course_Type_ID", "Course_Name", training_course.Training_Course_Type_ID);
            return View(training_course);
        }

        // POST: training_course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Training_Course_ID,Training_Course_Name,Training_Course_Description,Employee_ID,Training_Course_Type_ID")] training_course training_course)
        {
            bool val = db.training_course.Any(s => s.Training_Course_Name == training_course.Training_Course_Name && s.Training_Course_ID != training_course.Training_Course_ID);
            if (ModelState.IsValid && val == false)
            {
                db.Entry(training_course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an: " + training_course.Training_Course_Name + " type in the database.";
                ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", training_course.Employee_ID);
                ViewBag.Training_Course_Type_ID = new SelectList(db.training_course_type, "Training_Course_Type_ID", "Course_Name", training_course.Training_Course_Type_ID);
                return View();
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", training_course.Employee_ID);
            ViewBag.Training_Course_Type_ID = new SelectList(db.training_course_type, "Training_Course_Type_ID", "Course_Name", training_course.Training_Course_Type_ID);
            return View(training_course);
        }

        // GET: training_course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course training_course = db.training_course.Find(id);
            if (training_course == null)
            {
                return HttpNotFound();
            }
            return View(training_course);
        }

        // POST: training_course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            training_course training_course = db.training_course.Find(id);
            db.training_course.Remove(training_course);
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

        public bool Validate(string stri)
        {
            //var employees = from s in (db.employees.Include(e => e.address).Include(e => e.employee_type).Include(e => e.gender).Include(e => e.title)) select s;
            var checkTC = (from s in (db.training_course) where s.Training_Course_Name == stri select s).FirstOrDefault();
            if (checkTC != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
