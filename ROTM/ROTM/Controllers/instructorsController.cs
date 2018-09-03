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
    public class instructorsController : Controller
    {
        private Entities db = new Entities();

        // GET: instructors
        public ActionResult Index()
        {
            var instructors = db.instructors.Include(i => i.employee).Include(i => i.title).Include(i => i.gender).Include(i => i.instructor_type);
            return View(instructors.ToList());
        }

        // GET: instructors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor instructor = db.instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // GET: instructors/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name");
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1");
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1");
            ViewBag.Instructor_Type_ID = new SelectList(db.instructor_type, "Instructor_Type_ID", "Instructor_Type_Name");
            return View();
        }

        // POST: instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Instructor_ID,Instructor_Name,Instructor_Surname,Instructor_Email,Instructor_Cellphone,Employee_ID,Instructor_Type_ID,Title_ID,Gender_ID")] instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", instructor.Employee_ID);
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", instructor.Title_ID);
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", instructor.Gender_ID);
            ViewBag.Instructor_Type_ID = new SelectList(db.instructor_type, "Instructor_Type_ID", "Instructor_Type_Name", instructor.Instructor_Type_ID);
            return View(instructor);
        }

        // GET: instructors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor instructor = db.instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", instructor.Employee_ID);
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", instructor.Title_ID);
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", instructor.Gender_ID);
            ViewBag.Instructor_Type_ID = new SelectList(db.instructor_type, "Instructor_Type_ID", "Instructor_Type_Name", instructor.Instructor_Type_ID);
            return View(instructor);
        }

        // POST: instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Instructor_ID,Instructor_Name,Instructor_Surname,Instructor_Email,Instructor_Cellphone,Employee_ID,Instructor_Type_ID,Title_ID,Gender_ID")] instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", instructor.Employee_ID);
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", instructor.Title_ID);
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", instructor.Gender_ID);
            ViewBag.Instructor_Type_ID = new SelectList(db.instructor_type, "Instructor_Type_ID", "Instructor_Type_Name", instructor.Instructor_Type_ID);
            return View(instructor);
        }

        // GET: instructors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor instructor = db.instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            instructor instructor = db.instructors.Find(id);
            db.instructors.Remove(instructor);
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
