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
    public class employee_typeController : Controller
    {
        private Entities db = new Entities();

        // GET: employee_type
        public ActionResult Index()
        {
            return View(db.employee_type.ToList());
        }

        // GET: employee_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_type employee_type = db.employee_type.Find(id);
            if (employee_type == null)
            {
                return HttpNotFound();
            }
            return View(employee_type);
        }

        // GET: employee_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employee_type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_Type_ID,Type_Name,Type_Description")] employee_type employee_type)
        {
            bool val = Validate(employee_type.Type_Name);
            if (ModelState.IsValid && val == false)
            {
                db.employee_type.Add(employee_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an: " + employee_type.Type_Name + " type in the database.";
                return View();
            }
            return View(employee_type);
        }

        // GET: employee_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_type employee_type = db.employee_type.Find(id);
            if (employee_type == null)
            {
                return HttpNotFound();
            }
            return View(employee_type);
        }

        // POST: employee_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_Type_ID,Type_Name,Type_Description")] employee_type employee_type)
        {
            //bool val = Validate(employee_type.Type_Name, ValID);
            bool val = db.employee_type.Any(s => s.Type_Name == employee_type.Type_Name && s.Employee_Type_ID != employee_type.Employee_Type_ID);
            if (ModelState.IsValid && val == false)
            {
                db.Entry(employee_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an: " + employee_type.Type_Name + " type in the database.";
                return View();
            }
            return View(employee_type);
        }

        // GET: employee_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_type employee_type = db.employee_type.Find(id);
            if (employee_type == null)
            {
                return HttpNotFound();
            }
            return View(employee_type);
        }

        // POST: employee_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee_type employee_type = db.employee_type.Find(id);
            db.employee_type.Remove(employee_type);
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
            var checkEmployee = (from s in (db.employee_type) where s.Type_Name == stri select s).FirstOrDefault();
            if (checkEmployee != null)
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
