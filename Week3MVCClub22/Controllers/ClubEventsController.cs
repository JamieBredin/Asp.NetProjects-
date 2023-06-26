
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week3ClubDomain22.BusinessModel;

namespace Week3MVCClub22.Controllers
{
    public class ClubEventsController : Controller
    {
        private ClubsContext db = new ClubsContext();

        // GET: ClubEvents
        public ActionResult Index()
        {
            var clubEvents = db.ClubEvents.Include(c => c.associatedClub);
            return View(clubEvents.ToList());
        }

        // GET: ClubEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubEvent clubEvent = db.ClubEvents.Find(id);
            if (clubEvent == null)
            {
                return HttpNotFound();
            }
            return View(clubEvent);
        }

        // GET: ClubEvents/Create
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "ClubName");
            return View();
        }

        // POST: ClubEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,Venue,Location,ClubId,StartDateTime,EndDateTime")] ClubEvent clubEvent)
        {
            if (ModelState.IsValid)
            {
                db.ClubEvents.Add(clubEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "ClubName", clubEvent.ClubId);
            return View(clubEvent);
        }

        // GET: ClubEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubEvent clubEvent = db.ClubEvents.Find(id);
            if (clubEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "ClubName", clubEvent.ClubId);
            return View(clubEvent);
        }

        // POST: ClubEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,Venue,Location,ClubId,StartDateTime,EndDateTime")] ClubEvent clubEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "ClubName", clubEvent.ClubId);
            return View(clubEvent);
        }

        // GET: ClubEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubEvent clubEvent = db.ClubEvents.Find(id);
            if (clubEvent == null)
            {
                return HttpNotFound();
            }
            return View(clubEvent);
        }

        // POST: ClubEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClubEvent clubEvent = db.ClubEvents.Find(id);
            db.ClubEvents.Remove(clubEvent);
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
