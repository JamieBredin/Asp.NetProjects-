namespace Week09.MVC.S00211357.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tracker.WebAPIClient;
    using Week09.MVC.S00211357.Models;
    using Week9ClubDomain22;

    internal sealed class Configuration : DbMigrationsConfiguration<Week09.MVC.S00211357.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week09.MVC.S00211357.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin", activityName: "RAD301 Week 09 Lab 2223", Task: "Seeding Application Users and Roles");

            //Creating Manager and Role Manager
            var manager =
               new UserManager<ApplicationUser>(
                   new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            //Creating Admin, ClubAdmin and member roles
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "ClubAdmin" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "member" }
                );

            //hash password
            PasswordHasher ps = new PasswordHasher();

            //Creating an Admin User
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    EntityID = "admin",
                    UserName = "admin@itsligo.ie",
                    Email = "admin@itsligo.ie",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = ps.HashPassword("Rad3022021$1")
                });

            //Giving Admin User all Roles
            ApplicationUser admin = manager.FindByEmail("admin@itsligo.ie");
            if (admin != null)
            {
                manager.AddToRoles(admin.Id, new string[] { "Admin", "member", "ClubAdmin" });
            }
            context.SaveChanges();
            SeedApplicationMembers(manager, context);
            context.SaveChanges();
            //Saving changes
        }
        private void SeedApplicationMembers(UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            PasswordHasher ps = new PasswordHasher();

            using (Week09DbContext ClubContext = new Week09DbContext())
            {
                //Getting First Club
                List<Club> clubs = ClubContext.Clubs.ToList();
                //Giving first member to be part of admin group
                foreach (Club club in clubs)
                {
                    Member Administrator = club.clubMembers.First(m => m.MemberID == club.adminID);

                    //going through all the members and making them users and giving them member roles
                    foreach (Member m in club.clubMembers)
                    {
                        IdentityResult result = manager.Create(new ApplicationUser
                        {
                            EmailConfirmed = true,
                            EntityID = m.StudentID,
                            Email = m.StudentID + "@itsligo.ie",
                            UserName = m.StudentID + "@itsligo.ie",
                            SecurityStamp = Guid.NewGuid().ToString(),
                        }, m.StudentID + "$1");
                        if (result.Succeeded)
                        {
                            ApplicationUser clubMember = manager.FindByEmail(m.StudentID + "@itsligo.ie");
                            if (clubMember != null)
                            {
                                manager.AddToRoles(clubMember.Id, new string[] { "member" });
                            }
                        }
                    }

                    //Giving admin group the admin privilages
                    ApplicationUser adminMember = manager.FindByEmail(Administrator.StudentID + "@itsligo.ie");
                    if (adminMember != null)
                    {
                        manager.AddToRoles(adminMember.Id, new string[] { "ClubAdmin" });
                    }
                }
                context.SaveChanges();
                //saving changes
            }
        }
    }
}
