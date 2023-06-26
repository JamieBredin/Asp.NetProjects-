using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Rad3012223.MVC.Week5.Models;
using RAD3012223Week5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rad3012223.MVC.Week5.Controllers
{
    [Authorize(Roles = "Admin,ClubAdmin")]
    public class ClubAdminS00211357Controller : Controller
    {
        // GET: ClubAdminS00211357
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext
                    .GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private Week5ClubContext db = new Week5ClubContext();
        public ActionResult Index()
        {
            if (User.IsInRole("ClubAdmin"))
            {
                //Get the
                ApplicationUser clubAdmin = UserManager.FindByName(User.Identity.Name);
                Member adminMember = db.Members.FirstOrDefault(m => m.StudentID == clubAdmin.EntityID);

                if (adminMember == null)
                {
                    ViewBag.Name = User.Identity.Name + " You have a role but no clubs to Maintain";
                    return View();
                }
                ViewBag.Name = adminMember.studentMember.FirstName + " " + adminMember.studentMember.SecondName;
                List<Club> clubs = db.Clubs
                    .Where(p => p.adminID == adminMember.MemberID).ToList();
                return View(clubs);
            }
            else
            {
                ViewBag.Name = User.Identity.Name + " You are not Authorised to access any clubs";
                return View();
            }
        }
        public ActionResult Approve(int? ClubId)
        {
            Club club = db.Clubs.Find(ClubId);
            ClubViewModels mcvm = new ClubViewModels
            {
                ClubID = club.ClubId,
                clubName = club.ClubName,
                Unapproved = club.clubMembers.Where(m => m.approved == false).ToList(),
                Approved = club.clubMembers.Where(m => m.approved == true).ToList(),
            };
            return View(mcvm);
        }

        [HttpPost]
        public ActionResult Approve(ClubViewModels model)
        {
            if(ModelState.IsValid)
            {
                foreach (var member in model.Unapproved)
                    db.Members.Find(member.MemberID).approved = member.approved;
                foreach (var member in model.Approved)
                    db.Members.Find(member.MemberID).approved = member.approved;
                db.SaveChanges();
                return RedirectToAction("Approve", new {ClubId = model.ClubID});
            }
            return View(model);
        }
    }
}