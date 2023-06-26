using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tracker.WebAPIClient;
using Week10ClubDomain22;

namespace Week10MVCs00211357.Controllers
{
    public class StudentsController : Controller
    {
        private ClubsContext db = new ClubsContext();

        public StudentsController()
        {
            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin", activityName: "RAD301Week 10Lab2021", Task: "ImplementingDatePicker");
        }
        // GET: Students
        public ActionResult Index(string sort, string search, int? page)
        {
            ActivityAPIClient.Track(StudentID: "S00211357",
                StudentName: "Jamie Bredin",
                activityName: "RAD301Week 10 Lab 2022",
                Task: "Week11 Implementing a Modal Popup");

            ViewBag.CurrentSearch = search;
            IQueryable<Student> students = db.Student;
            ViewBag.SnameSort = sort == "sname" ? "sname_desc" : "sname";
            ViewBag.SnameSort = sort == "fname" ? "fname_desc" : "fname";
            ViewBag.SnameSort = sort == "Date" ? "date_desc" : "Date";
            if (!String.IsNullOrEmpty(search))
                students =
                    students.Where(
                        s => s.FirstName.StartsWith(search) || s.SecondName.StartsWith(search));
            switch(sort)
            {
                case "Date":
                    students = students.OrderBy(s=>s.DateRegistered);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.DateRegistered);
                    break;
                case "sname":
                    students = students.OrderBy(s => s.SecondName).ThenBy(s => s.FirstName);
                    break;
                case "sname_desc":
                    students = students.OrderByDescending(s => s.SecondName).ThenBy(s => s.FirstName);
                    break;
                    default:
                    students = students.OrderBy(s => s.SecondName).ThenBy(s => s.FirstName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return View(students.ToPagedList(pageNumber,pageSize));
        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,SecondName,DateRegistered")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,SecondName,DateRegistered")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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

        public ActionResult _Create()
        {
            return PartialView("_Create", new Student { DateRegistered = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Create([Bind(Include = "StudentID,FirstName,SecondName,DateRegistered")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

    }
}
