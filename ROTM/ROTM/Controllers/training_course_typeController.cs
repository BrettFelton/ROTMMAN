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
            bool val = Validate(training_course_type.Course_Name);
            if (ModelState.IsValid && val == false)
            {
                db.training_course_type.Add(training_course_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an: " + training_course_type.Course_Name + " type in the database.";
                return View();
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
            bool val = db.training_course_type.Any(s => s.Course_Name == training_course_type.Course_Name && s.Training_Course_Type_ID != training_course_type.Training_Course_Type_ID);
            if (ModelState.IsValid && val == false)
            {
                db.Entry(training_course_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an: " + training_course_type.Course_Name + " type in the database.";
                return View();
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

        public bool Validate(string stri)
        {
            //var employees = from s in (db.employees.Include(e => e.address).Include(e => e.employee_type).Include(e => e.gender).Include(e => e.title)) select s;
            var checkTC = (from s in (db.training_course_type) where s.Course_Name == stri select s).FirstOrDefault();
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
