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
    public class venuesController : Controller
    {
        private Entities db = new Entities();

        // GET: venues
        public ActionResult Index()
        {
            var venues = db.venues.Include(v => v.address);
            return View(venues.ToList());
        }

        // GET: venues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venue venue = db.venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // GET: venues/Create
        public ActionResult Create()
        {
            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name");
            return View();
        }

        // POST: venues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Venue_ID,Venue_Name,Venue_Description,Venue_Size,Address_ID")] venue venue)
        {
            if (ModelState.IsValid)
            {
                db.venues.Add(venue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", venue.Address_ID);
            return View(venue);
        }

        // GET: venues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venue venue = db.venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", venue.Address_ID);
            return View(venue);
        }

        // POST: venues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Venue_ID,Venue_Name,Venue_Description,Venue_Size,Address_ID")] venue venue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", venue.Address_ID);
            return View(venue);
        }

        // GET: venues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venue venue = db.venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // POST: venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            venue venue = db.venues.Find(id);
            db.venues.Remove(venue);
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
