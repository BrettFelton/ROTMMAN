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
            if (ModelState.IsValid)
            {
                db.employee_type.Add(employee_type);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            if (ModelState.IsValid)
            {
                db.Entry(employee_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
    }
}
