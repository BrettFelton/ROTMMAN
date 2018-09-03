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
{   [Authorize]
    public class bookingsController : Controller
    {
        private Entities db = new Entities();

        // GET: bookings
        public ActionResult Index(string searchString)
        {

            ViewData["CurrentFilter"] = searchString;

            var bookings = from s in (db.bookings.Include(b => b.address).Include(b => b.booking_type).Include(b => b.client).Include(b => b.employee)) select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                bookings = bookings.Where(s => s.Booking_Name.Contains(searchString) || s.Booking_Date.ToString().Contains(searchString) || s.Booking_Start_Time.ToString().Contains(searchString) || s.Booking_End_Time.ToString().Contains(searchString));
            }

            //var bookings = db.bookings.Include(b => b.address).Include(b => b.booking_type).Include(b => b.client).Include(b => b.employee);
            return View(bookings.ToList());
        }

        // GET: bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: bookings/Create
        public ActionResult Create()
        {
            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name");
            ViewBag.Booking_Type_ID = new SelectList(db.booking_type, "Booking_Type_ID", "Booking_Type_Name");
            ViewBag.Client_ID = new SelectList(db.clients, "Client_ID", "Client_Name");
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name");
            return View();
        }

        // POST: bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking_ID,Booking_Name,Booking_Date,Booking_Start_Time,Booking_End_Time,Booking_Type_ID,Client_ID,Employee_ID,Address_ID")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", booking.Address_ID);
            ViewBag.Booking_Type_ID = new SelectList(db.booking_type, "Booking_Type_ID", "Booking_Type_Name", booking.Booking_Type_ID);
            ViewBag.Client_ID = new SelectList(db.clients, "Client_ID", "Client_Name", booking.Client_ID);
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", booking.Employee_ID);
            return View(booking);
        }

        // GET: bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", booking.Address_ID);
            ViewBag.Booking_Type_ID = new SelectList(db.booking_type, "Booking_Type_ID", "Booking_Type_Name", booking.Booking_Type_ID);
            ViewBag.Client_ID = new SelectList(db.clients, "Client_ID", "Client_Name", booking.Client_ID);
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", booking.Employee_ID);
            return View(booking);
        }

        // POST: bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_ID,Booking_Name,Booking_Date,Booking_Start_Time,Booking_End_Time,Booking_Type_ID,Client_ID,Employee_ID,Address_ID")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", booking.Address_ID);
            ViewBag.Booking_Type_ID = new SelectList(db.booking_type, "Booking_Type_ID", "Booking_Type_Name", booking.Booking_Type_ID);
            ViewBag.Client_ID = new SelectList(db.clients, "Client_ID", "Client_Name", booking.Client_ID);
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", booking.Employee_ID);
            return View(booking);
        }

        // GET: bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            booking booking = db.bookings.Find(id);
            db.bookings.Remove(booking);
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
