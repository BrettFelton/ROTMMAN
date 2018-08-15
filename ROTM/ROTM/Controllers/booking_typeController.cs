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
    public class booking_typeController : Controller
    {
        private Entities db = new Entities();

        // GET: booking_type
        public ActionResult Index()
        {
            return View(db.booking_type.ToList());
        }

        // GET: booking_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking_type booking_type = db.booking_type.Find(id);
            if (booking_type == null)
            {
                return HttpNotFound();
            }
            return View(booking_type);
        }

        // GET: booking_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: booking_type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking_Type_ID,Booking_Type_Name,Booking_Type_Description")] booking_type booking_type)
        {
            if (ModelState.IsValid)
            {
                db.booking_type.Add(booking_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking_type);
        }

        // GET: booking_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking_type booking_type = db.booking_type.Find(id);
            if (booking_type == null)
            {
                return HttpNotFound();
            }
            return View(booking_type);
        }

        // POST: booking_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_Type_ID,Booking_Type_Name,Booking_Type_Description")] booking_type booking_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking_type);
        }

        // GET: booking_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking_type booking_type = db.booking_type.Find(id);
            if (booking_type == null)
            {
                return HttpNotFound();
            }
            return View(booking_type);
        }

        // POST: booking_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            booking_type booking_type = db.booking_type.Find(id);
            db.booking_type.Remove(booking_type);
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
