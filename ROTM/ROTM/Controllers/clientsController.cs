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
    public class clientsController : Controller
    {
        private Entities db = new Entities();

        // GET: clients
        public ActionResult Index()
        {
            var clients = db.clients.Include(c => c.client_rating).Include(c => c.client_type);
            return View(clients.ToList());
        }

        // GET: clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: clients/Create
        public ActionResult Create()
        {
            ViewBag.Client_Rating_ID = new SelectList(db.client_rating, "Client_Rating_ID", "Rating_Name");
            ViewBag.Client_Type_ID = new SelectList(db.client_type, "Client_Type_ID", "Client_Type_Name");
            return View();
        }

        // POST: clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Client_ID,Client_Name,Client_Cellphone,Client_Email,Client_Rating_ID,Client_Type_ID")] client client)
        {
            if (ModelState.IsValid)
            {
                db.clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Client_Rating_ID = new SelectList(db.client_rating, "Client_Rating_ID", "Rating_Name", client.Client_Rating_ID);
            ViewBag.Client_Type_ID = new SelectList(db.client_type, "Client_Type_ID", "Client_Type_Name", client.Client_Type_ID);
            return View(client);
        }

        // GET: clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.Client_Rating_ID = new SelectList(db.client_rating, "Client_Rating_ID", "Rating_Name", client.Client_Rating_ID);
            ViewBag.Client_Type_ID = new SelectList(db.client_type, "Client_Type_ID", "Client_Type_Name", client.Client_Type_ID);
            return View(client);
        }

        // POST: clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Client_ID,Client_Name,Client_Cellphone,Client_Email,Client_Rating_ID,Client_Type_ID")] client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Client_Rating_ID = new SelectList(db.client_rating, "Client_Rating_ID", "Rating_Name", client.Client_Rating_ID);
            ViewBag.Client_Type_ID = new SelectList(db.client_type, "Client_Type_ID", "Client_Type_Name", client.Client_Type_ID);
            return View(client);
        }

        // GET: clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            client client = db.clients.Find(id);
            db.clients.Remove(client);
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
