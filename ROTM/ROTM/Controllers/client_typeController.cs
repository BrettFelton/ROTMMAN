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
            bool val = Validate(client_type.Client_Type_Name);
            if (ModelState.IsValid && val == false)
            {
                db.client_type.Add(client_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an: " + client_type.Client_Type_Name + " type in the database.";
                return View();
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
            bool val = db.client_type.Any(s => s.Client_Type_Name == client_type.Client_Type_Name && s.Client_Type_ID != client_type.Client_Type_ID);
            if (ModelState.IsValid && val == false)
            {
                db.Entry(client_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an: " + client_type.Client_Type_Name + " type in the database.";
                return View();
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

        public bool Validate(string stri)
        {
            //var employees = from s in (db.employees.Include(e => e.address).Include(e => e.employee_type).Include(e => e.gender).Include(e => e.title)) select s;
            var checkClient = (from s in (db.client_type) where s.Client_Type_Name == stri select s).FirstOrDefault();
            if (checkClient != null)
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
