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
    public class client_typeController : Controller
    {
        private Entities db = new Entities();

        // GET: client_type
        public ActionResult Index()
        {
            return View(db.client_type.ToList());
        }

        // GET: client_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client_type client_type = db.client_type.Find(id);
            if (client_type == null)
            {
                return HttpNotFound();
            }
            return View(client_type);
        }

        // GET: client_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: client_type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Client_Type_ID,Client_Type_Name,Client_Type_Description")] client_type client_type)
        {
            if (ModelState.IsValid)
            {
                db.client_type.Add(client_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client_type);
        }

        // GET: client_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client_type client_type = db.client_type.Find(id);
            if (client_type == null)
            {
                return HttpNotFound();
            }
            return View(client_type);
        }

        // POST: client_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Client_Type_ID,Client_Type_Name,Client_Type_Description")] client_type client_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client_type);
        }

        // GET: client_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client_type client_type = db.client_type.Find(id);
            if (client_type == null)
            {
                return HttpNotFound();
            }
            return View(client_type);
        }

        // POST: client_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            client_type client_type = db.client_type.Find(id);
            db.client_type.Remove(client_type);
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
