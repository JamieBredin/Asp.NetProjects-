using ClubModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tracker.WebAPIClient;
namespace Week82022.MVC.Controllers
{
    public class ClubEventsController : Controller
    {
        ClubsContext db = new ClubsContext();

        private List<SelectListItem> FillClub()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            {
                var clubs = db.Clubs.ToList();
                foreach (var item in clubs)
                    items.Add(new SelectListItem()
                    {
                        Value=item.ClubId.ToString(),Text=item.ClubName
                    }
                        );
               
            }
            return items;
        }
        // GET: ClubEvents
        public ActionResult Index()
        {
            ActivityAPIClient.Track(StudentID: "S00211357",
                StudentName: "Jamie Bredin",
                activityName: "RAD301 Week 8 Lab 2021",
                Task: "Implementing Club Filter Dropdown box");

            List<SelectListItem> items = FillClub();
            items.First().Selected = true;
            ViewBag.Clubs = items;
            int cid = Int32.Parse(items.First().Value);
            return View(db.Clubs.FirstOrDefault(c=>c.ClubId == cid));
        }
        public async Task<ActionResult> AllClubDetails(string ClubName = null)
        {

            ActivityAPIClient.Track(StudentID: "S00211357",
                StudentName: "Jamie Bredin",
                activityName: "RAD301 Week 8 Lab 2021",
                Task: "Implementing Partial View");

            ViewBag.cname=ClubName;
            var fullClub = db.Clubs
                .Where(c => ClubName == null || c.ClubName.StartsWith(ClubName))
                .ToListAsync();
            return View(await fullClub);
        }

        [HttpPost]
        public ActionResult Index(Club model)
        {
            List<SelectListItem> items = FillClub();
            items.First(s => s.Value == model.ClubId.ToString());
            ViewBag.Clubs = items;
            return View(db.Clubs.FirstOrDefault(c => c.ClubId == model.ClubId));
        }
    }
}